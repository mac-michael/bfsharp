using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace BFsharp
{
    [DataContract(IsReference = true)]
    public abstract partial class AbstractEntityBase : INotifyPropertyChanged, IEntityBase
#if NET
        ,IDataErrorInfo
#endif
#if SILVERLIGHT
        ,INotifyDataErrorInfo
#endif
    {
        public AbstractEntityBase()
        {
            _extensions = CreateExtensions();
#if SILVERLIGHT
            _extensions.BrokenRules.RuleBroken += OnBrokenRuleChanged;
            _extensions.BrokenRules.RuleRepaired += OnBrokenRuleChanged;
#endif
        }

        private readonly IEntityExtensions _extensions;
        IEntityExtensions IEntityBase.Extensions { get { return _extensions; } }
        
        protected virtual IEntityExtensions CreateExtensions()
        {
            var entityExtensions = EntityExtensions.RegisterObject(this);
            //entityExtensions.StartGraphMonitoring();
            return entityExtensions;
        }

        #region IDataErrorInfo

        public string this[string columnName]
        {
            get
            {
                var message = string.Join(Environment.NewLine,
                                          ((IEntityBase)this).Extensions.BrokenRules.Where(r => r.Severity == BrokenRuleSeverity.Error && r.Owner == columnName)
                                              .Select(r => r.Message).ToArray());

                return string.IsNullOrEmpty(message) ? null : message;
            }
        }

        public string Error
        {
            get { return string.Join(Environment.NewLine, ((IEntityBase)this).Extensions.BrokenRules.Select(r => r.Message).ToArray()); }
        }

        #endregion
#if SILVERLIGHT
        #region INotifyDataErrorInfo

        public IEnumerable GetErrors(string propertyName)
        {
            return ((IEntityBase)this).Extensions.BrokenRules.Where(r => r.Owner == propertyName);
        }

        public bool HasErrors
        {
            get { return ((IEntityBase)this).Extensions.BrokenRules.Count > 0; }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        
        void OnBrokenRuleChanged(object sender, BrokenRuleEventArgs e)
        {
            var errorChanged = ErrorsChanged;
            if (errorChanged!= null)
                errorChanged(this, new DataErrorsChangedEventArgs(e.BrokenRule.Owner));
        }
        #endregion
#endif
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
                changed(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}