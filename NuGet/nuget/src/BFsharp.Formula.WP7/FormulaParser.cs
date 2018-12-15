// $ANTLR 3.1.3 Mar 17, 2009 19:23:44 D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g 2011-07-27 23:01:41

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

namespace  BFsharp.Formula 
{
public partial class FormulaParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"METHOD", 
		"LAMBDA", 
		"PARAM", 
		"TYPENAME", 
		"ID", 
		"IntegerLiteral", 
		"DecimalLiteral", 
		"StringLiteral", 
		"BooleanLiteral", 
		"PLUS", 
		"MINUS", 
		"MULTIPLY", 
		"DIVIDE", 
		"MODULO", 
		"EQUALS", 
		"NOTEQUALS", 
		"OR", 
		"AND", 
		"LESS", 
		"LESSOREQUALS", 
		"GREATER", 
		"GREATEROREQUALS", 
		"CALL", 
		"IntegerTypeSuffix", 
		"Exponent", 
		"FloatTypeSuffix", 
		"WS", 
		"COMMENT", 
		"LINE_COMMENT", 
		"'rule'", 
		"'{'", 
		"'}'", 
		"'property'", 
		"','", 
		"';'", 
		"':'", 
		"'='", 
		"'?'", 
		"'('", 
		"')'", 
		"'=>'"
    };

    public const int FloatTypeSuffix = 29;
    public const int Exponent = 28;
    public const int PARAM = 6;
    public const int EQUALS = 18;
    public const int GREATEROREQUALS = 25;
    public const int ID = 8;
    public const int AND = 21;
    public const int EOF = -1;
    public const int GREATER = 24;
    public const int MULTIPLY = 15;
    public const int LESS = 22;
    public const int PLUS = 13;
    public const int LAMBDA = 5;
    public const int COMMENT = 31;
    public const int DIVIDE = 16;
    public const int T__42 = 42;
    public const int TYPENAME = 7;
    public const int T__43 = 43;
    public const int T__40 = 40;
    public const int T__41 = 41;
    public const int MODULO = 17;
    public const int T__44 = 44;
    public const int LINE_COMMENT = 32;
    public const int IntegerTypeSuffix = 27;
    public const int LESSOREQUALS = 23;
    public const int NOTEQUALS = 19;
    public const int MINUS = 14;
    public const int DecimalLiteral = 10;
    public const int StringLiteral = 11;
    public const int T__33 = 33;
    public const int WS = 30;
    public const int T__34 = 34;
    public const int T__35 = 35;
    public const int T__36 = 36;
    public const int T__37 = 37;
    public const int T__38 = 38;
    public const int T__39 = 39;
    public const int OR = 20;
    public const int CALL = 26;
    public const int IntegerLiteral = 9;
    public const int METHOD = 4;
    public const int BooleanLiteral = 12;

    // delegates
    // delegators



        public FormulaParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public FormulaParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
        }
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return FormulaParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g"; }
    }


    public class startEntity_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "startEntity"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:19:1: startEntity : ( rules )? ( properties )? EOF ;
    public FormulaParser.startEntity_return startEntity() // throws RecognitionException [1]
    {   
        FormulaParser.startEntity_return retval = new FormulaParser.startEntity_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken EOF3 = null;
        FormulaParser.rules_return rules1 = default(FormulaParser.rules_return);

        FormulaParser.properties_return properties2 = default(FormulaParser.properties_return);


        CommonTree EOF3_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:19:12: ( ( rules )? ( properties )? EOF )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:19:14: ( rules )? ( properties )? EOF
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:19:14: ( rules )?
            	int alt1 = 2;
            	int LA1_0 = input.LA(1);

            	if ( (LA1_0 == 33) )
            	{
            	    alt1 = 1;
            	}
            	switch (alt1) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:19:14: rules
            	        {
            	        	PushFollow(FOLLOW_rules_in_startEntity79);
            	        	rules1 = rules();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, rules1.Tree);

            	        }
            	        break;

            	}

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:19:21: ( properties )?
            	int alt2 = 2;
            	int LA2_0 = input.LA(1);

            	if ( (LA2_0 == 36) )
            	{
            	    alt2 = 1;
            	}
            	switch (alt2) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:19:21: properties
            	        {
            	        	PushFollow(FOLLOW_properties_in_startEntity82);
            	        	properties2 = properties();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, properties2.Tree);

            	        }
            	        break;

            	}

            	EOF3=(IToken)Match(input,EOF,FOLLOW_EOF_in_startEntity85); 
            		EOF3_tree = (CommonTree)adaptor.Create(EOF3);
            		adaptor.AddChild(root_0, EOF3_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "startEntity"

    public class rules_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "rules"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:21:1: rules : 'rule' '{' ( rule )* '}' ;
    public FormulaParser.rules_return rules() // throws RecognitionException [1]
    {   
        FormulaParser.rules_return retval = new FormulaParser.rules_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken string_literal4 = null;
        IToken char_literal5 = null;
        IToken char_literal7 = null;
        FormulaParser.rule_return rule6 = default(FormulaParser.rule_return);


        CommonTree string_literal4_tree=null;
        CommonTree char_literal5_tree=null;
        CommonTree char_literal7_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:21:7: ( 'rule' '{' ( rule )* '}' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:21:9: 'rule' '{' ( rule )* '}'
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	string_literal4=(IToken)Match(input,33,FOLLOW_33_in_rules93); 
            		string_literal4_tree = (CommonTree)adaptor.Create(string_literal4);
            		root_0 = (CommonTree)adaptor.BecomeRoot(string_literal4_tree, root_0);

            	char_literal5=(IToken)Match(input,34,FOLLOW_34_in_rules96); 
            		char_literal5_tree = (CommonTree)adaptor.Create(char_literal5);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal5_tree, root_0);

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:21:22: ( rule )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( ((LA3_0 >= ID && LA3_0 <= BooleanLiteral) || LA3_0 == MINUS || LA3_0 == 42) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:21:22: rule
            			    {
            			    	PushFollow(FOLLOW_rule_in_rules99);
            			    	rule6 = rule();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, rule6.Tree);

            			    }
            			    break;

            			default:
            			    goto loop3;
            	    }
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements

            	char_literal7=(IToken)Match(input,35,FOLLOW_35_in_rules102); 
            		char_literal7_tree = (CommonTree)adaptor.Create(char_literal7);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal7_tree, root_0);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "rules"

    public class properties_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "properties"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:22:1: properties : 'property' '{' ( property )* '}' ;
    public FormulaParser.properties_return properties() // throws RecognitionException [1]
    {   
        FormulaParser.properties_return retval = new FormulaParser.properties_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken string_literal8 = null;
        IToken char_literal9 = null;
        IToken char_literal11 = null;
        FormulaParser.property_return property10 = default(FormulaParser.property_return);


        CommonTree string_literal8_tree=null;
        CommonTree char_literal9_tree=null;
        CommonTree char_literal11_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:23:2: ( 'property' '{' ( property )* '}' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:23:5: 'property' '{' ( property )* '}'
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	string_literal8=(IToken)Match(input,36,FOLLOW_36_in_properties112); 
            		string_literal8_tree = (CommonTree)adaptor.Create(string_literal8);
            		root_0 = (CommonTree)adaptor.BecomeRoot(string_literal8_tree, root_0);

            	char_literal9=(IToken)Match(input,34,FOLLOW_34_in_properties115); 
            		char_literal9_tree = (CommonTree)adaptor.Create(char_literal9);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal9_tree, root_0);

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:23:22: ( property )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( (LA4_0 == ID) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:23:22: property
            			    {
            			    	PushFollow(FOLLOW_property_in_properties118);
            			    	property10 = property();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, property10.Tree);

            			    }
            			    break;

            			default:
            			    goto loop4;
            	    }
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements

            	char_literal11=(IToken)Match(input,35,FOLLOW_35_in_properties121); 
            		char_literal11_tree = (CommonTree)adaptor.Create(char_literal11);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal11_tree, root_0);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "properties"

    public class rule_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "rule"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:1: rule : ( ruleType )? ( businessRule )? conditionalExpression ( ',' conditionalExpression )* ( settings )? ';' ;
    public FormulaParser.rule_return rule() // throws RecognitionException [1]
    {   
        FormulaParser.rule_return retval = new FormulaParser.rule_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal15 = null;
        IToken char_literal18 = null;
        FormulaParser.ruleType_return ruleType12 = default(FormulaParser.ruleType_return);

        FormulaParser.businessRule_return businessRule13 = default(FormulaParser.businessRule_return);

        FormulaParser.conditionalExpression_return conditionalExpression14 = default(FormulaParser.conditionalExpression_return);

        FormulaParser.conditionalExpression_return conditionalExpression16 = default(FormulaParser.conditionalExpression_return);

        FormulaParser.settings_return settings17 = default(FormulaParser.settings_return);


        CommonTree char_literal15_tree=null;
        CommonTree char_literal18_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:6: ( ( ruleType )? ( businessRule )? conditionalExpression ( ',' conditionalExpression )* ( settings )? ';' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:8: ( ruleType )? ( businessRule )? conditionalExpression ( ',' conditionalExpression )* ( settings )? ';'
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:8: ( ruleType )?
            	int alt5 = 2;
            	int LA5_0 = input.LA(1);

            	if ( (LA5_0 == ID) )
            	{
            	    int LA5_1 = input.LA(2);

            	    if ( (LA5_1 == 39) )
            	    {
            	        alt5 = 1;
            	    }
            	}
            	switch (alt5) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:8: ruleType
            	        {
            	        	PushFollow(FOLLOW_ruleType_in_rule131);
            	        	ruleType12 = ruleType();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, ruleType12.Tree);

            	        }
            	        break;

            	}

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:18: ( businessRule )?
            	int alt6 = 2;
            	alt6 = dfa6.Predict(input);
            	switch (alt6) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:18: businessRule
            	        {
            	        	PushFollow(FOLLOW_businessRule_in_rule134);
            	        	businessRule13 = businessRule();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, businessRule13.Tree);

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_conditionalExpression_in_rule137);
            	conditionalExpression14 = conditionalExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, conditionalExpression14.Tree);
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:54: ( ',' conditionalExpression )*
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);

            	    if ( (LA7_0 == 37) )
            	    {
            	        alt7 = 1;
            	    }


            	    switch (alt7) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:55: ',' conditionalExpression
            			    {
            			    	char_literal15=(IToken)Match(input,37,FOLLOW_37_in_rule140); 
            			    		char_literal15_tree = (CommonTree)adaptor.Create(char_literal15);
            			    		adaptor.AddChild(root_0, char_literal15_tree);

            			    	PushFollow(FOLLOW_conditionalExpression_in_rule142);
            			    	conditionalExpression16 = conditionalExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, conditionalExpression16.Tree);

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:83: ( settings )?
            	int alt8 = 2;
            	int LA8_0 = input.LA(1);

            	if ( (LA8_0 == 34) )
            	{
            	    alt8 = 1;
            	}
            	switch (alt8) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:25:83: settings
            	        {
            	        	PushFollow(FOLLOW_settings_in_rule146);
            	        	settings17 = settings();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, settings17.Tree);

            	        }
            	        break;

            	}

            	char_literal18=(IToken)Match(input,38,FOLLOW_38_in_rule149); 
            		char_literal18_tree = (CommonTree)adaptor.Create(char_literal18);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal18_tree, root_0);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "rule"

    public class property_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "property"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:26:1: property : ID ID ';' ;
    public FormulaParser.property_return property() // throws RecognitionException [1]
    {   
        FormulaParser.property_return retval = new FormulaParser.property_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken ID19 = null;
        IToken ID20 = null;
        IToken char_literal21 = null;

        CommonTree ID19_tree=null;
        CommonTree ID20_tree=null;
        CommonTree char_literal21_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:26:9: ( ID ID ';' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:26:11: ID ID ';'
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	ID19=(IToken)Match(input,ID,FOLLOW_ID_in_property156); 
            		ID19_tree = (CommonTree)adaptor.Create(ID19);
            		adaptor.AddChild(root_0, ID19_tree);

            	ID20=(IToken)Match(input,ID,FOLLOW_ID_in_property158); 
            		ID20_tree = (CommonTree)adaptor.Create(ID20);
            		adaptor.AddChild(root_0, ID20_tree);

            	char_literal21=(IToken)Match(input,38,FOLLOW_38_in_property160); 
            		char_literal21_tree = (CommonTree)adaptor.Create(char_literal21);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal21_tree, root_0);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "property"

    public class ruleType_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "ruleType"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:28:1: ruleType : ID ':' ;
    public FormulaParser.ruleType_return ruleType() // throws RecognitionException [1]
    {   
        FormulaParser.ruleType_return retval = new FormulaParser.ruleType_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken ID22 = null;
        IToken char_literal23 = null;

        CommonTree ID22_tree=null;
        CommonTree char_literal23_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:28:9: ( ID ':' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:28:11: ID ':'
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	ID22=(IToken)Match(input,ID,FOLLOW_ID_in_ruleType168); 
            		ID22_tree = (CommonTree)adaptor.Create(ID22);
            		adaptor.AddChild(root_0, ID22_tree);

            	char_literal23=(IToken)Match(input,39,FOLLOW_39_in_ruleType170); 
            		char_literal23_tree = (CommonTree)adaptor.Create(char_literal23);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal23_tree, root_0);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "ruleType"

    public class businessRule_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "businessRule"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:29:1: businessRule : ID ( '.' ID )* '=' ;
    public FormulaParser.businessRule_return businessRule() // throws RecognitionException [1]
    {   
        FormulaParser.businessRule_return retval = new FormulaParser.businessRule_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken ID24 = null;
        IToken char_literal25 = null;
        IToken ID26 = null;
        IToken char_literal27 = null;

        CommonTree ID24_tree=null;
        CommonTree char_literal25_tree=null;
        CommonTree ID26_tree=null;
        CommonTree char_literal27_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:30:2: ( ID ( '.' ID )* '=' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:30:4: ID ( '.' ID )* '='
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	ID24=(IToken)Match(input,ID,FOLLOW_ID_in_businessRule179); 
            		ID24_tree = (CommonTree)adaptor.Create(ID24);
            		adaptor.AddChild(root_0, ID24_tree);

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:30:7: ( '.' ID )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);

            	    if ( (LA9_0 == CALL) )
            	    {
            	        alt9 = 1;
            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:30:8: '.' ID
            			    {
            			    	char_literal25=(IToken)Match(input,CALL,FOLLOW_CALL_in_businessRule182); 
            			    		char_literal25_tree = (CommonTree)adaptor.Create(char_literal25);
            			    		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal25_tree, root_0);

            			    	ID26=(IToken)Match(input,ID,FOLLOW_ID_in_businessRule185); 
            			    		ID26_tree = (CommonTree)adaptor.Create(ID26);
            			    		adaptor.AddChild(root_0, ID26_tree);


            			    }
            			    break;

            			default:
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements

            	char_literal27=(IToken)Match(input,40,FOLLOW_40_in_businessRule189); 
            		char_literal27_tree = (CommonTree)adaptor.Create(char_literal27);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal27_tree, root_0);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "businessRule"

    public class settings_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "settings"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:32:1: settings : '{' ( setting )? ( ',' setting )* '}' ;
    public FormulaParser.settings_return settings() // throws RecognitionException [1]
    {   
        FormulaParser.settings_return retval = new FormulaParser.settings_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal28 = null;
        IToken char_literal30 = null;
        IToken char_literal32 = null;
        FormulaParser.setting_return setting29 = default(FormulaParser.setting_return);

        FormulaParser.setting_return setting31 = default(FormulaParser.setting_return);


        CommonTree char_literal28_tree=null;
        CommonTree char_literal30_tree=null;
        CommonTree char_literal32_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:32:9: ( '{' ( setting )? ( ',' setting )* '}' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:32:11: '{' ( setting )? ( ',' setting )* '}'
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	char_literal28=(IToken)Match(input,34,FOLLOW_34_in_settings197); 
            		char_literal28_tree = (CommonTree)adaptor.Create(char_literal28);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal28_tree, root_0);

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:32:16: ( setting )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( (LA10_0 == ID) )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:32:16: setting
            	        {
            	        	PushFollow(FOLLOW_setting_in_settings200);
            	        	setting29 = setting();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, setting29.Tree);

            	        }
            	        break;

            	}

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:32:25: ( ',' setting )*
            	do 
            	{
            	    int alt11 = 2;
            	    int LA11_0 = input.LA(1);

            	    if ( (LA11_0 == 37) )
            	    {
            	        alt11 = 1;
            	    }


            	    switch (alt11) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:32:26: ',' setting
            			    {
            			    	char_literal30=(IToken)Match(input,37,FOLLOW_37_in_settings204); 
            			    		char_literal30_tree = (CommonTree)adaptor.Create(char_literal30);
            			    		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal30_tree, root_0);

            			    	PushFollow(FOLLOW_setting_in_settings207);
            			    	setting31 = setting();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, setting31.Tree);

            			    }
            			    break;

            			default:
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements

            	char_literal32=(IToken)Match(input,35,FOLLOW_35_in_settings211); 
            		char_literal32_tree = (CommonTree)adaptor.Create(char_literal32);
            		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal32_tree, root_0);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "settings"

    public class setting_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "setting"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:33:1: setting : ID '=' settingValue ;
    public FormulaParser.setting_return setting() // throws RecognitionException [1]
    {   
        FormulaParser.setting_return retval = new FormulaParser.setting_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken ID33 = null;
        IToken char_literal34 = null;
        FormulaParser.settingValue_return settingValue35 = default(FormulaParser.settingValue_return);


        CommonTree ID33_tree=null;
        CommonTree char_literal34_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:33:8: ( ID '=' settingValue )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:33:10: ID '=' settingValue
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	ID33=(IToken)Match(input,ID,FOLLOW_ID_in_setting218); 
            		ID33_tree = (CommonTree)adaptor.Create(ID33);
            		adaptor.AddChild(root_0, ID33_tree);

            	char_literal34=(IToken)Match(input,40,FOLLOW_40_in_setting220); 
            		char_literal34_tree = (CommonTree)adaptor.Create(char_literal34);
            		adaptor.AddChild(root_0, char_literal34_tree);

            	PushFollow(FOLLOW_settingValue_in_setting222);
            	settingValue35 = settingValue();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, settingValue35.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "setting"

    public class settingValue_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "settingValue"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:35:1: settingValue : ( ID | IntegerLiteral | DecimalLiteral | StringLiteral | BooleanLiteral );
    public FormulaParser.settingValue_return settingValue() // throws RecognitionException [1]
    {   
        FormulaParser.settingValue_return retval = new FormulaParser.settingValue_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken set36 = null;

        CommonTree set36_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:35:13: ( ID | IntegerLiteral | DecimalLiteral | StringLiteral | BooleanLiteral )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	set36 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= ID && input.LA(1) <= BooleanLiteral) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set36));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "settingValue"

    public class start_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "start"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:40:1: start : expression EOF ;
    public FormulaParser.start_return start() // throws RecognitionException [1]
    {   
        FormulaParser.start_return retval = new FormulaParser.start_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken EOF38 = null;
        FormulaParser.expression_return expression37 = default(FormulaParser.expression_return);


        CommonTree EOF38_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:40:6: ( expression EOF )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:41:2: expression EOF
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	PushFollow(FOLLOW_expression_in_start263);
            	expression37 = expression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, expression37.Tree);
            	EOF38=(IToken)Match(input,EOF,FOLLOW_EOF_in_start265); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "start"

    public class expression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "expression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:43:1: expression : ( conditionalExpression | lambda_expression );
    public FormulaParser.expression_return expression() // throws RecognitionException [1]
    {   
        FormulaParser.expression_return retval = new FormulaParser.expression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        FormulaParser.conditionalExpression_return conditionalExpression39 = default(FormulaParser.conditionalExpression_return);

        FormulaParser.lambda_expression_return lambda_expression40 = default(FormulaParser.lambda_expression_return);



        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:44:2: ( conditionalExpression | lambda_expression )
            int alt12 = 2;
            alt12 = dfa12.Predict(input);
            switch (alt12) 
            {
                case 1 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:44:5: conditionalExpression
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_conditionalExpression_in_expression276);
                    	conditionalExpression39 = conditionalExpression();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, conditionalExpression39.Tree);

                    }
                    break;
                case 2 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:44:29: lambda_expression
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_lambda_expression_in_expression280);
                    	lambda_expression40 = lambda_expression();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, lambda_expression40.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expression"

    public class conditionalExpression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "conditionalExpression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:46:1: conditionalExpression : conditionalOrExpression ( '?' conditionalExpression ':' conditionalExpression )? ;
    public FormulaParser.conditionalExpression_return conditionalExpression() // throws RecognitionException [1]
    {   
        FormulaParser.conditionalExpression_return retval = new FormulaParser.conditionalExpression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal42 = null;
        IToken char_literal44 = null;
        FormulaParser.conditionalOrExpression_return conditionalOrExpression41 = default(FormulaParser.conditionalOrExpression_return);

        FormulaParser.conditionalExpression_return conditionalExpression43 = default(FormulaParser.conditionalExpression_return);

        FormulaParser.conditionalExpression_return conditionalExpression45 = default(FormulaParser.conditionalExpression_return);


        CommonTree char_literal42_tree=null;
        CommonTree char_literal44_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:47:5: ( conditionalOrExpression ( '?' conditionalExpression ':' conditionalExpression )? )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:47:9: conditionalOrExpression ( '?' conditionalExpression ':' conditionalExpression )?
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	PushFollow(FOLLOW_conditionalOrExpression_in_conditionalExpression294);
            	conditionalOrExpression41 = conditionalOrExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, conditionalOrExpression41.Tree);
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:47:33: ( '?' conditionalExpression ':' conditionalExpression )?
            	int alt13 = 2;
            	int LA13_0 = input.LA(1);

            	if ( (LA13_0 == 41) )
            	{
            	    alt13 = 1;
            	}
            	switch (alt13) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:47:35: '?' conditionalExpression ':' conditionalExpression
            	        {
            	        	char_literal42=(IToken)Match(input,41,FOLLOW_41_in_conditionalExpression298); 
            	        		char_literal42_tree = (CommonTree)adaptor.Create(char_literal42);
            	        		adaptor.AddChild(root_0, char_literal42_tree);

            	        	PushFollow(FOLLOW_conditionalExpression_in_conditionalExpression300);
            	        	conditionalExpression43 = conditionalExpression();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, conditionalExpression43.Tree);
            	        	char_literal44=(IToken)Match(input,39,FOLLOW_39_in_conditionalExpression302); 
            	        		char_literal44_tree = (CommonTree)adaptor.Create(char_literal44);
            	        		adaptor.AddChild(root_0, char_literal44_tree);

            	        	PushFollow(FOLLOW_conditionalExpression_in_conditionalExpression304);
            	        	conditionalExpression45 = conditionalExpression();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, conditionalExpression45.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "conditionalExpression"

    public class conditionalOrExpression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "conditionalOrExpression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:50:1: conditionalOrExpression : conditionalAndExpression ( '||' conditionalAndExpression )* ;
    public FormulaParser.conditionalOrExpression_return conditionalOrExpression() // throws RecognitionException [1]
    {   
        FormulaParser.conditionalOrExpression_return retval = new FormulaParser.conditionalOrExpression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken string_literal47 = null;
        FormulaParser.conditionalAndExpression_return conditionalAndExpression46 = default(FormulaParser.conditionalAndExpression_return);

        FormulaParser.conditionalAndExpression_return conditionalAndExpression48 = default(FormulaParser.conditionalAndExpression_return);


        CommonTree string_literal47_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:51:5: ( conditionalAndExpression ( '||' conditionalAndExpression )* )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:51:9: conditionalAndExpression ( '||' conditionalAndExpression )*
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	PushFollow(FOLLOW_conditionalAndExpression_in_conditionalOrExpression326);
            	conditionalAndExpression46 = conditionalAndExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, conditionalAndExpression46.Tree);
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:51:34: ( '||' conditionalAndExpression )*
            	do 
            	{
            	    int alt14 = 2;
            	    int LA14_0 = input.LA(1);

            	    if ( (LA14_0 == OR) )
            	    {
            	        alt14 = 1;
            	    }


            	    switch (alt14) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:51:36: '||' conditionalAndExpression
            			    {
            			    	string_literal47=(IToken)Match(input,OR,FOLLOW_OR_in_conditionalOrExpression330); 
            			    		string_literal47_tree = (CommonTree)adaptor.Create(string_literal47);
            			    		root_0 = (CommonTree)adaptor.BecomeRoot(string_literal47_tree, root_0);

            			    	PushFollow(FOLLOW_conditionalAndExpression_in_conditionalOrExpression333);
            			    	conditionalAndExpression48 = conditionalAndExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, conditionalAndExpression48.Tree);

            			    }
            			    break;

            			default:
            			    goto loop14;
            	    }
            	} while (true);

            	loop14:
            		;	// Stops C# compiler whining that label 'loop14' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "conditionalOrExpression"

    public class conditionalAndExpression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "conditionalAndExpression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:54:1: conditionalAndExpression : equalityExpression ( '&&' equalityExpression )* ;
    public FormulaParser.conditionalAndExpression_return conditionalAndExpression() // throws RecognitionException [1]
    {   
        FormulaParser.conditionalAndExpression_return retval = new FormulaParser.conditionalAndExpression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken string_literal50 = null;
        FormulaParser.equalityExpression_return equalityExpression49 = default(FormulaParser.equalityExpression_return);

        FormulaParser.equalityExpression_return equalityExpression51 = default(FormulaParser.equalityExpression_return);


        CommonTree string_literal50_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:55:5: ( equalityExpression ( '&&' equalityExpression )* )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:55:9: equalityExpression ( '&&' equalityExpression )*
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	PushFollow(FOLLOW_equalityExpression_in_conditionalAndExpression355);
            	equalityExpression49 = equalityExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, equalityExpression49.Tree);
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:55:28: ( '&&' equalityExpression )*
            	do 
            	{
            	    int alt15 = 2;
            	    int LA15_0 = input.LA(1);

            	    if ( (LA15_0 == AND) )
            	    {
            	        alt15 = 1;
            	    }


            	    switch (alt15) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:55:30: '&&' equalityExpression
            			    {
            			    	string_literal50=(IToken)Match(input,AND,FOLLOW_AND_in_conditionalAndExpression359); 
            			    		string_literal50_tree = (CommonTree)adaptor.Create(string_literal50);
            			    		root_0 = (CommonTree)adaptor.BecomeRoot(string_literal50_tree, root_0);

            			    	PushFollow(FOLLOW_equalityExpression_in_conditionalAndExpression362);
            			    	equalityExpression51 = equalityExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, equalityExpression51.Tree);

            			    }
            			    break;

            			default:
            			    goto loop15;
            	    }
            	} while (true);

            	loop15:
            		;	// Stops C# compiler whining that label 'loop15' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "conditionalAndExpression"

    public class equalityExpression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "equalityExpression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:58:1: equalityExpression : relationalExpression ( ( '==' | '!=' ) relationalExpression )* ;
    public FormulaParser.equalityExpression_return equalityExpression() // throws RecognitionException [1]
    {   
        FormulaParser.equalityExpression_return retval = new FormulaParser.equalityExpression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken string_literal53 = null;
        IToken string_literal54 = null;
        FormulaParser.relationalExpression_return relationalExpression52 = default(FormulaParser.relationalExpression_return);

        FormulaParser.relationalExpression_return relationalExpression55 = default(FormulaParser.relationalExpression_return);


        CommonTree string_literal53_tree=null;
        CommonTree string_literal54_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:59:5: ( relationalExpression ( ( '==' | '!=' ) relationalExpression )* )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:59:9: relationalExpression ( ( '==' | '!=' ) relationalExpression )*
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	PushFollow(FOLLOW_relationalExpression_in_equalityExpression384);
            	relationalExpression52 = relationalExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, relationalExpression52.Tree);
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:59:30: ( ( '==' | '!=' ) relationalExpression )*
            	do 
            	{
            	    int alt17 = 2;
            	    int LA17_0 = input.LA(1);

            	    if ( ((LA17_0 >= EQUALS && LA17_0 <= NOTEQUALS)) )
            	    {
            	        alt17 = 1;
            	    }


            	    switch (alt17) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:59:32: ( '==' | '!=' ) relationalExpression
            			    {
            			    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:59:32: ( '==' | '!=' )
            			    	int alt16 = 2;
            			    	int LA16_0 = input.LA(1);

            			    	if ( (LA16_0 == EQUALS) )
            			    	{
            			    	    alt16 = 1;
            			    	}
            			    	else if ( (LA16_0 == NOTEQUALS) )
            			    	{
            			    	    alt16 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d16s0 =
            			    	        new NoViableAltException("", 16, 0, input);

            			    	    throw nvae_d16s0;
            			    	}
            			    	switch (alt16) 
            			    	{
            			    	    case 1 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:59:33: '=='
            			    	        {
            			    	        	string_literal53=(IToken)Match(input,EQUALS,FOLLOW_EQUALS_in_equalityExpression389); 
            			    	        		string_literal53_tree = (CommonTree)adaptor.Create(string_literal53);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(string_literal53_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:59:41: '!='
            			    	        {
            			    	        	string_literal54=(IToken)Match(input,NOTEQUALS,FOLLOW_NOTEQUALS_in_equalityExpression394); 
            			    	        		string_literal54_tree = (CommonTree)adaptor.Create(string_literal54);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(string_literal54_tree, root_0);


            			    	        }
            			    	        break;

            			    	}

            			    	PushFollow(FOLLOW_relationalExpression_in_equalityExpression398);
            			    	relationalExpression55 = relationalExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, relationalExpression55.Tree);

            			    }
            			    break;

            			default:
            			    goto loop17;
            	    }
            	} while (true);

            	loop17:
            		;	// Stops C# compiler whining that label 'loop17' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "equalityExpression"

    public class relationalExpression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "relationalExpression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:62:1: relationalExpression : additiveExpression ( ( '<=' | '>=' | '<' | '>' ) additiveExpression )* ;
    public FormulaParser.relationalExpression_return relationalExpression() // throws RecognitionException [1]
    {   
        FormulaParser.relationalExpression_return retval = new FormulaParser.relationalExpression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken string_literal57 = null;
        IToken string_literal58 = null;
        IToken char_literal59 = null;
        IToken char_literal60 = null;
        FormulaParser.additiveExpression_return additiveExpression56 = default(FormulaParser.additiveExpression_return);

        FormulaParser.additiveExpression_return additiveExpression61 = default(FormulaParser.additiveExpression_return);


        CommonTree string_literal57_tree=null;
        CommonTree string_literal58_tree=null;
        CommonTree char_literal59_tree=null;
        CommonTree char_literal60_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:63:5: ( additiveExpression ( ( '<=' | '>=' | '<' | '>' ) additiveExpression )* )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:63:9: additiveExpression ( ( '<=' | '>=' | '<' | '>' ) additiveExpression )*
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	PushFollow(FOLLOW_additiveExpression_in_relationalExpression420);
            	additiveExpression56 = additiveExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, additiveExpression56.Tree);
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:63:28: ( ( '<=' | '>=' | '<' | '>' ) additiveExpression )*
            	do 
            	{
            	    int alt19 = 2;
            	    int LA19_0 = input.LA(1);

            	    if ( ((LA19_0 >= LESS && LA19_0 <= GREATEROREQUALS)) )
            	    {
            	        alt19 = 1;
            	    }


            	    switch (alt19) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:63:30: ( '<=' | '>=' | '<' | '>' ) additiveExpression
            			    {
            			    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:63:30: ( '<=' | '>=' | '<' | '>' )
            			    	int alt18 = 4;
            			    	switch ( input.LA(1) ) 
            			    	{
            			    	case LESSOREQUALS:
            			    		{
            			    	    alt18 = 1;
            			    	    }
            			    	    break;
            			    	case GREATEROREQUALS:
            			    		{
            			    	    alt18 = 2;
            			    	    }
            			    	    break;
            			    	case LESS:
            			    		{
            			    	    alt18 = 3;
            			    	    }
            			    	    break;
            			    	case GREATER:
            			    		{
            			    	    alt18 = 4;
            			    	    }
            			    	    break;
            			    		default:
            			    		    NoViableAltException nvae_d18s0 =
            			    		        new NoViableAltException("", 18, 0, input);

            			    		    throw nvae_d18s0;
            			    	}

            			    	switch (alt18) 
            			    	{
            			    	    case 1 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:63:31: '<='
            			    	        {
            			    	        	string_literal57=(IToken)Match(input,LESSOREQUALS,FOLLOW_LESSOREQUALS_in_relationalExpression425); 
            			    	        		string_literal57_tree = (CommonTree)adaptor.Create(string_literal57);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(string_literal57_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:63:39: '>='
            			    	        {
            			    	        	string_literal58=(IToken)Match(input,GREATEROREQUALS,FOLLOW_GREATEROREQUALS_in_relationalExpression430); 
            			    	        		string_literal58_tree = (CommonTree)adaptor.Create(string_literal58);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(string_literal58_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 3 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:63:47: '<'
            			    	        {
            			    	        	char_literal59=(IToken)Match(input,LESS,FOLLOW_LESS_in_relationalExpression435); 
            			    	        		char_literal59_tree = (CommonTree)adaptor.Create(char_literal59);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal59_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 4 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:63:54: '>'
            			    	        {
            			    	        	char_literal60=(IToken)Match(input,GREATER,FOLLOW_GREATER_in_relationalExpression440); 
            			    	        		char_literal60_tree = (CommonTree)adaptor.Create(char_literal60);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal60_tree, root_0);


            			    	        }
            			    	        break;

            			    	}

            			    	PushFollow(FOLLOW_additiveExpression_in_relationalExpression444);
            			    	additiveExpression61 = additiveExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, additiveExpression61.Tree);

            			    }
            			    break;

            			default:
            			    goto loop19;
            	    }
            	} while (true);

            	loop19:
            		;	// Stops C# compiler whining that label 'loop19' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "relationalExpression"

    public class additiveExpression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "additiveExpression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:67:1: additiveExpression : ( multiplicativeExpression ) ( ( '+' | '-' ) multiplicativeExpression )* ;
    public FormulaParser.additiveExpression_return additiveExpression() // throws RecognitionException [1]
    {   
        FormulaParser.additiveExpression_return retval = new FormulaParser.additiveExpression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal63 = null;
        IToken char_literal64 = null;
        FormulaParser.multiplicativeExpression_return multiplicativeExpression62 = default(FormulaParser.multiplicativeExpression_return);

        FormulaParser.multiplicativeExpression_return multiplicativeExpression65 = default(FormulaParser.multiplicativeExpression_return);


        CommonTree char_literal63_tree=null;
        CommonTree char_literal64_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:67:19: ( ( multiplicativeExpression ) ( ( '+' | '-' ) multiplicativeExpression )* )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:68:2: ( multiplicativeExpression ) ( ( '+' | '-' ) multiplicativeExpression )*
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:68:2: ( multiplicativeExpression )
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:68:3: multiplicativeExpression
            	{
            		PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression465);
            		multiplicativeExpression62 = multiplicativeExpression();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, multiplicativeExpression62.Tree);

            	}

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:68:29: ( ( '+' | '-' ) multiplicativeExpression )*
            	do 
            	{
            	    int alt21 = 2;
            	    int LA21_0 = input.LA(1);

            	    if ( ((LA21_0 >= PLUS && LA21_0 <= MINUS)) )
            	    {
            	        alt21 = 1;
            	    }


            	    switch (alt21) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:68:30: ( '+' | '-' ) multiplicativeExpression
            			    {
            			    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:68:30: ( '+' | '-' )
            			    	int alt20 = 2;
            			    	int LA20_0 = input.LA(1);

            			    	if ( (LA20_0 == PLUS) )
            			    	{
            			    	    alt20 = 1;
            			    	}
            			    	else if ( (LA20_0 == MINUS) )
            			    	{
            			    	    alt20 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d20s0 =
            			    	        new NoViableAltException("", 20, 0, input);

            			    	    throw nvae_d20s0;
            			    	}
            			    	switch (alt20) 
            			    	{
            			    	    case 1 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:68:31: '+'
            			    	        {
            			    	        	char_literal63=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_additiveExpression470); 
            			    	        		char_literal63_tree = (CommonTree)adaptor.Create(char_literal63);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal63_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:68:36: '-'
            			    	        {
            			    	        	char_literal64=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_additiveExpression473); 
            			    	        		char_literal64_tree = (CommonTree)adaptor.Create(char_literal64);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal64_tree, root_0);


            			    	        }
            			    	        break;

            			    	}

            			    	PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression477);
            			    	multiplicativeExpression65 = multiplicativeExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, multiplicativeExpression65.Tree);

            			    }
            			    break;

            			default:
            			    goto loop21;
            	    }
            	} while (true);

            	loop21:
            		;	// Stops C# compiler whining that label 'loop21' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "additiveExpression"

    public class multiplicativeExpression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "multiplicativeExpression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:69:1: multiplicativeExpression : ( unaryExpression ) ( ( '*' | '/' | '%' ) unaryExpression )* ;
    public FormulaParser.multiplicativeExpression_return multiplicativeExpression() // throws RecognitionException [1]
    {   
        FormulaParser.multiplicativeExpression_return retval = new FormulaParser.multiplicativeExpression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal67 = null;
        IToken char_literal68 = null;
        IToken char_literal69 = null;
        FormulaParser.unaryExpression_return unaryExpression66 = default(FormulaParser.unaryExpression_return);

        FormulaParser.unaryExpression_return unaryExpression70 = default(FormulaParser.unaryExpression_return);


        CommonTree char_literal67_tree=null;
        CommonTree char_literal68_tree=null;
        CommonTree char_literal69_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:69:25: ( ( unaryExpression ) ( ( '*' | '/' | '%' ) unaryExpression )* )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:70:2: ( unaryExpression ) ( ( '*' | '/' | '%' ) unaryExpression )*
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:70:2: ( unaryExpression )
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:70:3: unaryExpression
            	{
            		PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression487);
            		unaryExpression66 = unaryExpression();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, unaryExpression66.Tree);

            	}

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:70:20: ( ( '*' | '/' | '%' ) unaryExpression )*
            	do 
            	{
            	    int alt23 = 2;
            	    int LA23_0 = input.LA(1);

            	    if ( ((LA23_0 >= MULTIPLY && LA23_0 <= MODULO)) )
            	    {
            	        alt23 = 1;
            	    }


            	    switch (alt23) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:70:21: ( '*' | '/' | '%' ) unaryExpression
            			    {
            			    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:70:21: ( '*' | '/' | '%' )
            			    	int alt22 = 3;
            			    	switch ( input.LA(1) ) 
            			    	{
            			    	case MULTIPLY:
            			    		{
            			    	    alt22 = 1;
            			    	    }
            			    	    break;
            			    	case DIVIDE:
            			    		{
            			    	    alt22 = 2;
            			    	    }
            			    	    break;
            			    	case MODULO:
            			    		{
            			    	    alt22 = 3;
            			    	    }
            			    	    break;
            			    		default:
            			    		    NoViableAltException nvae_d22s0 =
            			    		        new NoViableAltException("", 22, 0, input);

            			    		    throw nvae_d22s0;
            			    	}

            			    	switch (alt22) 
            			    	{
            			    	    case 1 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:70:22: '*'
            			    	        {
            			    	        	char_literal67=(IToken)Match(input,MULTIPLY,FOLLOW_MULTIPLY_in_multiplicativeExpression492); 
            			    	        		char_literal67_tree = (CommonTree)adaptor.Create(char_literal67);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal67_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:70:27: '/'
            			    	        {
            			    	        	char_literal68=(IToken)Match(input,DIVIDE,FOLLOW_DIVIDE_in_multiplicativeExpression495); 
            			    	        		char_literal68_tree = (CommonTree)adaptor.Create(char_literal68);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal68_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 3 :
            			    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:70:32: '%'
            			    	        {
            			    	        	char_literal69=(IToken)Match(input,MODULO,FOLLOW_MODULO_in_multiplicativeExpression498); 
            			    	        		char_literal69_tree = (CommonTree)adaptor.Create(char_literal69);
            			    	        		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal69_tree, root_0);


            			    	        }
            			    	        break;

            			    	}

            			    	PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression502);
            			    	unaryExpression70 = unaryExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, unaryExpression70.Tree);

            			    }
            			    break;

            			default:
            			    goto loop23;
            	    }
            	} while (true);

            	loop23:
            		;	// Stops C# compiler whining that label 'loop23' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "multiplicativeExpression"

    public class unaryExpression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "unaryExpression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:71:1: unaryExpression : ( '-' unaryExpression | term );
    public FormulaParser.unaryExpression_return unaryExpression() // throws RecognitionException [1]
    {   
        FormulaParser.unaryExpression_return retval = new FormulaParser.unaryExpression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal71 = null;
        FormulaParser.unaryExpression_return unaryExpression72 = default(FormulaParser.unaryExpression_return);

        FormulaParser.term_return term73 = default(FormulaParser.term_return);


        CommonTree char_literal71_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:71:16: ( '-' unaryExpression | term )
            int alt24 = 2;
            int LA24_0 = input.LA(1);

            if ( (LA24_0 == MINUS) )
            {
                alt24 = 1;
            }
            else if ( ((LA24_0 >= ID && LA24_0 <= BooleanLiteral) || LA24_0 == 42) )
            {
                alt24 = 2;
            }
            else 
            {
                NoViableAltException nvae_d24s0 =
                    new NoViableAltException("", 24, 0, input);

                throw nvae_d24s0;
            }
            switch (alt24) 
            {
                case 1 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:72:6: '-' unaryExpression
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	char_literal71=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_unaryExpression515); 
                    		char_literal71_tree = (CommonTree)adaptor.Create(char_literal71);
                    		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal71_tree, root_0);

                    	PushFollow(FOLLOW_unaryExpression_in_unaryExpression518);
                    	unaryExpression72 = unaryExpression();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, unaryExpression72.Tree);

                    }
                    break;
                case 2 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:73:10: term
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_term_in_unaryExpression529);
                    	term73 = term();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, term73.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "unaryExpression"

    public class term_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "term"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:74:1: term : ( call | IntegerLiteral | DecimalLiteral | StringLiteral | BooleanLiteral | '(' conditionalExpression ')' );
    public FormulaParser.term_return term() // throws RecognitionException [1]
    {   
        FormulaParser.term_return retval = new FormulaParser.term_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken IntegerLiteral75 = null;
        IToken DecimalLiteral76 = null;
        IToken StringLiteral77 = null;
        IToken BooleanLiteral78 = null;
        IToken char_literal79 = null;
        IToken char_literal81 = null;
        FormulaParser.call_return call74 = default(FormulaParser.call_return);

        FormulaParser.conditionalExpression_return conditionalExpression80 = default(FormulaParser.conditionalExpression_return);


        CommonTree IntegerLiteral75_tree=null;
        CommonTree DecimalLiteral76_tree=null;
        CommonTree StringLiteral77_tree=null;
        CommonTree BooleanLiteral78_tree=null;
        CommonTree char_literal79_tree=null;
        CommonTree char_literal81_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:74:5: ( call | IntegerLiteral | DecimalLiteral | StringLiteral | BooleanLiteral | '(' conditionalExpression ')' )
            int alt25 = 6;
            switch ( input.LA(1) ) 
            {
            case ID:
            	{
                alt25 = 1;
                }
                break;
            case IntegerLiteral:
            	{
                alt25 = 2;
                }
                break;
            case DecimalLiteral:
            	{
                alt25 = 3;
                }
                break;
            case StringLiteral:
            	{
                alt25 = 4;
                }
                break;
            case BooleanLiteral:
            	{
                alt25 = 5;
                }
                break;
            case 42:
            	{
                alt25 = 6;
                }
                break;
            	default:
            	    NoViableAltException nvae_d25s0 =
            	        new NoViableAltException("", 25, 0, input);

            	    throw nvae_d25s0;
            }

            switch (alt25) 
            {
                case 1 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:75:2: call
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_call_in_term536);
                    	call74 = call();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, call74.Tree);

                    }
                    break;
                case 2 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:76:6: IntegerLiteral
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	IntegerLiteral75=(IToken)Match(input,IntegerLiteral,FOLLOW_IntegerLiteral_in_term543); 
                    		IntegerLiteral75_tree = (CommonTree)adaptor.Create(IntegerLiteral75);
                    		adaptor.AddChild(root_0, IntegerLiteral75_tree);


                    }
                    break;
                case 3 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:77:6: DecimalLiteral
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	DecimalLiteral76=(IToken)Match(input,DecimalLiteral,FOLLOW_DecimalLiteral_in_term550); 
                    		DecimalLiteral76_tree = (CommonTree)adaptor.Create(DecimalLiteral76);
                    		adaptor.AddChild(root_0, DecimalLiteral76_tree);


                    }
                    break;
                case 4 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:78:6: StringLiteral
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	StringLiteral77=(IToken)Match(input,StringLiteral,FOLLOW_StringLiteral_in_term557); 
                    		StringLiteral77_tree = (CommonTree)adaptor.Create(StringLiteral77);
                    		adaptor.AddChild(root_0, StringLiteral77_tree);


                    }
                    break;
                case 5 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:79:6: BooleanLiteral
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	BooleanLiteral78=(IToken)Match(input,BooleanLiteral,FOLLOW_BooleanLiteral_in_term564); 
                    		BooleanLiteral78_tree = (CommonTree)adaptor.Create(BooleanLiteral78);
                    		adaptor.AddChild(root_0, BooleanLiteral78_tree);


                    }
                    break;
                case 6 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:80:6: '(' conditionalExpression ')'
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	char_literal79=(IToken)Match(input,42,FOLLOW_42_in_term571); 
                    	PushFollow(FOLLOW_conditionalExpression_in_term574);
                    	conditionalExpression80 = conditionalExpression();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, conditionalExpression80.Tree);
                    	char_literal81=(IToken)Match(input,43,FOLLOW_43_in_term576); 

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "term"

    public class call_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "call"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:82:1: call : method ( '.' method )* ;
    public FormulaParser.call_return call() // throws RecognitionException [1]
    {   
        FormulaParser.call_return retval = new FormulaParser.call_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal83 = null;
        FormulaParser.method_return method82 = default(FormulaParser.method_return);

        FormulaParser.method_return method84 = default(FormulaParser.method_return);


        CommonTree char_literal83_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:82:5: ( method ( '.' method )* )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:82:8: method ( '.' method )*
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	PushFollow(FOLLOW_method_in_call585);
            	method82 = method();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, method82.Tree);
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:82:15: ( '.' method )*
            	do 
            	{
            	    int alt26 = 2;
            	    int LA26_0 = input.LA(1);

            	    if ( (LA26_0 == CALL) )
            	    {
            	        alt26 = 1;
            	    }


            	    switch (alt26) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:82:16: '.' method
            			    {
            			    	char_literal83=(IToken)Match(input,CALL,FOLLOW_CALL_in_call588); 
            			    		char_literal83_tree = (CommonTree)adaptor.Create(char_literal83);
            			    		root_0 = (CommonTree)adaptor.BecomeRoot(char_literal83_tree, root_0);

            			    	PushFollow(FOLLOW_method_in_call591);
            			    	method84 = method();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, method84.Tree);

            			    }
            			    break;

            			default:
            			    goto loop26;
            	    }
            	} while (true);

            	loop26:
            		;	// Stops C# compiler whining that label 'loop26' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "call"

    public class method_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "method"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:84:1: method : ID ( '(' (e+= expression )? ( ',' e+= expression )* ')' )? -> ^( METHOD ID ( $e)* ) ;
    public FormulaParser.method_return method() // throws RecognitionException [1]
    {   
        FormulaParser.method_return retval = new FormulaParser.method_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken ID85 = null;
        IToken char_literal86 = null;
        IToken char_literal87 = null;
        IToken char_literal88 = null;
        IList list_e = null;
        FormulaParser.expression_return e = default(FormulaParser.expression_return);
         e = null;
        CommonTree ID85_tree=null;
        CommonTree char_literal86_tree=null;
        CommonTree char_literal87_tree=null;
        CommonTree char_literal88_tree=null;
        RewriteRuleTokenStream stream_43 = new RewriteRuleTokenStream(adaptor,"token 43");
        RewriteRuleTokenStream stream_42 = new RewriteRuleTokenStream(adaptor,"token 42");
        RewriteRuleTokenStream stream_ID = new RewriteRuleTokenStream(adaptor,"token ID");
        RewriteRuleTokenStream stream_37 = new RewriteRuleTokenStream(adaptor,"token 37");
        RewriteRuleSubtreeStream stream_expression = new RewriteRuleSubtreeStream(adaptor,"rule expression");
        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:84:7: ( ID ( '(' (e+= expression )? ( ',' e+= expression )* ')' )? -> ^( METHOD ID ( $e)* ) )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:85:2: ID ( '(' (e+= expression )? ( ',' e+= expression )* ')' )?
            {
            	ID85=(IToken)Match(input,ID,FOLLOW_ID_in_method602);  
            	stream_ID.Add(ID85);

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:85:5: ( '(' (e+= expression )? ( ',' e+= expression )* ')' )?
            	int alt29 = 2;
            	int LA29_0 = input.LA(1);

            	if ( (LA29_0 == 42) )
            	{
            	    alt29 = 1;
            	}
            	switch (alt29) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:85:6: '(' (e+= expression )? ( ',' e+= expression )* ')'
            	        {
            	        	char_literal86=(IToken)Match(input,42,FOLLOW_42_in_method605);  
            	        	stream_42.Add(char_literal86);

            	        	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:85:11: (e+= expression )?
            	        	int alt27 = 2;
            	        	int LA27_0 = input.LA(1);

            	        	if ( ((LA27_0 >= ID && LA27_0 <= BooleanLiteral) || LA27_0 == MINUS || LA27_0 == 42) )
            	        	{
            	        	    alt27 = 1;
            	        	}
            	        	switch (alt27) 
            	        	{
            	        	    case 1 :
            	        	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:85:11: e+= expression
            	        	        {
            	        	        	PushFollow(FOLLOW_expression_in_method609);
            	        	        	e = expression();
            	        	        	state.followingStackPointer--;

            	        	        	stream_expression.Add(e.Tree);
            	        	        	if (list_e == null) list_e = new ArrayList();
            	        	        	list_e.Add(e.Tree);


            	        	        }
            	        	        break;

            	        	}

            	        	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:85:25: ( ',' e+= expression )*
            	        	do 
            	        	{
            	        	    int alt28 = 2;
            	        	    int LA28_0 = input.LA(1);

            	        	    if ( (LA28_0 == 37) )
            	        	    {
            	        	        alt28 = 1;
            	        	    }


            	        	    switch (alt28) 
            	        		{
            	        			case 1 :
            	        			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:85:26: ',' e+= expression
            	        			    {
            	        			    	char_literal87=(IToken)Match(input,37,FOLLOW_37_in_method613);  
            	        			    	stream_37.Add(char_literal87);

            	        			    	PushFollow(FOLLOW_expression_in_method618);
            	        			    	e = expression();
            	        			    	state.followingStackPointer--;

            	        			    	stream_expression.Add(e.Tree);
            	        			    	if (list_e == null) list_e = new ArrayList();
            	        			    	list_e.Add(e.Tree);


            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop28;
            	        	    }
            	        	} while (true);

            	        	loop28:
            	        		;	// Stops C# compiler whining that label 'loop28' has no statements

            	        	char_literal88=(IToken)Match(input,43,FOLLOW_43_in_method622);  
            	        	stream_43.Add(char_literal88);


            	        }
            	        break;

            	}



            	// AST REWRITE
            	// elements:          e, ID
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  e
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);
            	RewriteRuleSubtreeStream stream_e = new RewriteRuleSubtreeStream(adaptor, "token e", list_e);
            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 85:53: -> ^( METHOD ID ( $e)* )
            	{
            	    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:85:56: ^( METHOD ID ( $e)* )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(METHOD, "METHOD"), root_1);

            	    adaptor.AddChild(root_1, stream_ID.NextNode());
            	    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:85:68: ( $e)*
            	    while ( stream_e.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_e.NextTree());

            	    }
            	    stream_e.Reset();

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "method"

    public class lambda_expression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "lambda_expression"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:87:1: lambda_expression : s= anonymous_function_signature '=>' e= expression -> ^( LAMBDA $s $e) ;
    public FormulaParser.lambda_expression_return lambda_expression() // throws RecognitionException [1]
    {   
        FormulaParser.lambda_expression_return retval = new FormulaParser.lambda_expression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken string_literal89 = null;
        FormulaParser.anonymous_function_signature_return s = default(FormulaParser.anonymous_function_signature_return);

        FormulaParser.expression_return e = default(FormulaParser.expression_return);


        CommonTree string_literal89_tree=null;
        RewriteRuleTokenStream stream_44 = new RewriteRuleTokenStream(adaptor,"token 44");
        RewriteRuleSubtreeStream stream_expression = new RewriteRuleSubtreeStream(adaptor,"rule expression");
        RewriteRuleSubtreeStream stream_anonymous_function_signature = new RewriteRuleSubtreeStream(adaptor,"rule anonymous_function_signature");
        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:87:18: (s= anonymous_function_signature '=>' e= expression -> ^( LAMBDA $s $e) )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:88:2: s= anonymous_function_signature '=>' e= expression
            {
            	PushFollow(FOLLOW_anonymous_function_signature_in_lambda_expression646);
            	s = anonymous_function_signature();
            	state.followingStackPointer--;

            	stream_anonymous_function_signature.Add(s.Tree);
            	string_literal89=(IToken)Match(input,44,FOLLOW_44_in_lambda_expression648);  
            	stream_44.Add(string_literal89);

            	PushFollow(FOLLOW_expression_in_lambda_expression652);
            	e = expression();
            	state.followingStackPointer--;

            	stream_expression.Add(e.Tree);


            	// AST REWRITE
            	// elements:          e, s
            	// token labels:      
            	// rule labels:       retval, e, s
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);
            	RewriteRuleSubtreeStream stream_e = new RewriteRuleSubtreeStream(adaptor, "rule e", e!=null ? e.Tree : null);
            	RewriteRuleSubtreeStream stream_s = new RewriteRuleSubtreeStream(adaptor, "rule s", s!=null ? s.Tree : null);

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 88:51: -> ^( LAMBDA $s $e)
            	{
            	    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:88:54: ^( LAMBDA $s $e)
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(LAMBDA, "LAMBDA"), root_1);

            	    adaptor.AddChild(root_1, stream_s.NextTree());
            	    adaptor.AddChild(root_1, stream_e.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "lambda_expression"

    public class anonymous_function_signature_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "anonymous_function_signature"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:90:1: anonymous_function_signature : explicit_anonymous_function_signature ;
    public FormulaParser.anonymous_function_signature_return anonymous_function_signature() // throws RecognitionException [1]
    {   
        FormulaParser.anonymous_function_signature_return retval = new FormulaParser.anonymous_function_signature_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        FormulaParser.explicit_anonymous_function_signature_return explicit_anonymous_function_signature90 = default(FormulaParser.explicit_anonymous_function_signature_return);



        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:90:29: ( explicit_anonymous_function_signature )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:91:2: explicit_anonymous_function_signature
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	PushFollow(FOLLOW_explicit_anonymous_function_signature_in_anonymous_function_signature672);
            	explicit_anonymous_function_signature90 = explicit_anonymous_function_signature();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, explicit_anonymous_function_signature90.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "anonymous_function_signature"

    public class explicit_anonymous_function_signature_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "explicit_anonymous_function_signature"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:95:1: explicit_anonymous_function_signature : '(' explicit_anonymous_function_parameter_list ')' ;
    public FormulaParser.explicit_anonymous_function_signature_return explicit_anonymous_function_signature() // throws RecognitionException [1]
    {   
        FormulaParser.explicit_anonymous_function_signature_return retval = new FormulaParser.explicit_anonymous_function_signature_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal91 = null;
        IToken char_literal93 = null;
        FormulaParser.explicit_anonymous_function_parameter_list_return explicit_anonymous_function_parameter_list92 = default(FormulaParser.explicit_anonymous_function_parameter_list_return);


        CommonTree char_literal91_tree=null;
        CommonTree char_literal93_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:95:38: ( '(' explicit_anonymous_function_parameter_list ')' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:96:2: '(' explicit_anonymous_function_parameter_list ')'
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	char_literal91=(IToken)Match(input,42,FOLLOW_42_in_explicit_anonymous_function_signature683); 
            	PushFollow(FOLLOW_explicit_anonymous_function_parameter_list_in_explicit_anonymous_function_signature686);
            	explicit_anonymous_function_parameter_list92 = explicit_anonymous_function_parameter_list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, explicit_anonymous_function_parameter_list92.Tree);
            	char_literal93=(IToken)Match(input,43,FOLLOW_43_in_explicit_anonymous_function_signature688); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "explicit_anonymous_function_signature"

    public class explicit_anonymous_function_parameter_list_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "explicit_anonymous_function_parameter_list"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:99:1: explicit_anonymous_function_parameter_list : explicit_anonymous_function_parameter ( ',' explicit_anonymous_function_parameter )? ;
    public FormulaParser.explicit_anonymous_function_parameter_list_return explicit_anonymous_function_parameter_list() // throws RecognitionException [1]
    {   
        FormulaParser.explicit_anonymous_function_parameter_list_return retval = new FormulaParser.explicit_anonymous_function_parameter_list_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal95 = null;
        FormulaParser.explicit_anonymous_function_parameter_return explicit_anonymous_function_parameter94 = default(FormulaParser.explicit_anonymous_function_parameter_return);

        FormulaParser.explicit_anonymous_function_parameter_return explicit_anonymous_function_parameter96 = default(FormulaParser.explicit_anonymous_function_parameter_return);


        CommonTree char_literal95_tree=null;

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:99:43: ( explicit_anonymous_function_parameter ( ',' explicit_anonymous_function_parameter )? )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:100:2: explicit_anonymous_function_parameter ( ',' explicit_anonymous_function_parameter )?
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	PushFollow(FOLLOW_explicit_anonymous_function_parameter_in_explicit_anonymous_function_parameter_list699);
            	explicit_anonymous_function_parameter94 = explicit_anonymous_function_parameter();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, explicit_anonymous_function_parameter94.Tree);
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:100:40: ( ',' explicit_anonymous_function_parameter )?
            	int alt30 = 2;
            	int LA30_0 = input.LA(1);

            	if ( (LA30_0 == 37) )
            	{
            	    alt30 = 1;
            	}
            	switch (alt30) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:100:41: ',' explicit_anonymous_function_parameter
            	        {
            	        	char_literal95=(IToken)Match(input,37,FOLLOW_37_in_explicit_anonymous_function_parameter_list702); 
            	        	PushFollow(FOLLOW_explicit_anonymous_function_parameter_in_explicit_anonymous_function_parameter_list707);
            	        	explicit_anonymous_function_parameter96 = explicit_anonymous_function_parameter();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, explicit_anonymous_function_parameter96.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "explicit_anonymous_function_parameter_list"

    public class explicit_anonymous_function_parameter_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "explicit_anonymous_function_parameter"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:101:1: explicit_anonymous_function_parameter : typeName ID -> ^( PARAM typeName ID ) ;
    public FormulaParser.explicit_anonymous_function_parameter_return explicit_anonymous_function_parameter() // throws RecognitionException [1]
    {   
        FormulaParser.explicit_anonymous_function_parameter_return retval = new FormulaParser.explicit_anonymous_function_parameter_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken ID98 = null;
        FormulaParser.typeName_return typeName97 = default(FormulaParser.typeName_return);


        CommonTree ID98_tree=null;
        RewriteRuleTokenStream stream_ID = new RewriteRuleTokenStream(adaptor,"token ID");
        RewriteRuleSubtreeStream stream_typeName = new RewriteRuleSubtreeStream(adaptor,"rule typeName");
        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:101:38: ( typeName ID -> ^( PARAM typeName ID ) )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:102:2: typeName ID
            {
            	PushFollow(FOLLOW_typeName_in_explicit_anonymous_function_parameter717);
            	typeName97 = typeName();
            	state.followingStackPointer--;

            	stream_typeName.Add(typeName97.Tree);
            	ID98=(IToken)Match(input,ID,FOLLOW_ID_in_explicit_anonymous_function_parameter719);  
            	stream_ID.Add(ID98);



            	// AST REWRITE
            	// elements:          typeName, ID
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 102:14: -> ^( PARAM typeName ID )
            	{
            	    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:102:17: ^( PARAM typeName ID )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(PARAM, "PARAM"), root_1);

            	    adaptor.AddChild(root_1, stream_typeName.NextTree());
            	    adaptor.AddChild(root_1, stream_ID.NextNode());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "explicit_anonymous_function_parameter"

    public class typeName_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "typeName"
    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:104:1: typeName : e= ID ( '.' e= ID )* -> ^( TYPENAME $e) ;
    public FormulaParser.typeName_return typeName() // throws RecognitionException [1]
    {   
        FormulaParser.typeName_return retval = new FormulaParser.typeName_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken e = null;
        IToken char_literal99 = null;

        CommonTree e_tree=null;
        CommonTree char_literal99_tree=null;
        RewriteRuleTokenStream stream_CALL = new RewriteRuleTokenStream(adaptor,"token CALL");
        RewriteRuleTokenStream stream_ID = new RewriteRuleTokenStream(adaptor,"token ID");

        try 
    	{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:104:9: (e= ID ( '.' e= ID )* -> ^( TYPENAME $e) )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:104:11: e= ID ( '.' e= ID )*
            {
            	e=(IToken)Match(input,ID,FOLLOW_ID_in_typeName738);  
            	stream_ID.Add(e);

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:104:16: ( '.' e= ID )*
            	do 
            	{
            	    int alt31 = 2;
            	    int LA31_0 = input.LA(1);

            	    if ( (LA31_0 == CALL) )
            	    {
            	        alt31 = 1;
            	    }


            	    switch (alt31) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:104:18: '.' e= ID
            			    {
            			    	char_literal99=(IToken)Match(input,CALL,FOLLOW_CALL_in_typeName742);  
            			    	stream_CALL.Add(char_literal99);

            			    	e=(IToken)Match(input,ID,FOLLOW_ID_in_typeName746);  
            			    	stream_ID.Add(e);


            			    }
            			    break;

            			default:
            			    goto loop31;
            	    }
            	} while (true);

            	loop31:
            		;	// Stops C# compiler whining that label 'loop31' has no statements



            	// AST REWRITE
            	// elements:          e
            	// token labels:      e
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleTokenStream stream_e = new RewriteRuleTokenStream(adaptor, "token e", e);
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 104:30: -> ^( TYPENAME $e)
            	{
            	    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:104:33: ^( TYPENAME $e)
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(TYPENAME, "TYPENAME"), root_1);

            	    adaptor.AddChild(root_1, stream_e.NextNode());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "typeName"

    // Delegated rules


   	protected DFA6 dfa6;
   	protected DFA12 dfa12;
	private void InitializeCyclicDFAs()
	{
    	this.dfa6 = new DFA6(this);
    	this.dfa12 = new DFA12(this);


	}

    const string DFA6_eotS =
        "\x06\uffff";
    const string DFA6_eofS =
        "\x06\uffff";
    const string DFA6_minS =
        "\x01\x08\x01\x0d\x01\uffff\x01\x08\x01\uffff\x01\x0d";
    const string DFA6_maxS =
        "\x02\x2a\x01\uffff\x01\x08\x01\uffff\x01\x2a";
    const string DFA6_acceptS =
        "\x02\uffff\x01\x02\x01\uffff\x01\x01\x01\uffff";
    const string DFA6_specialS =
        "\x06\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x01\x04\x02\x01\uffff\x01\x02\x1b\uffff\x01\x02",
            "\x0d\x02\x01\x03\x07\uffff\x01\x02\x02\uffff\x02\x02\x01\uffff"+
            "\x01\x04\x02\x02",
            "",
            "\x01\x05",
            "",
            "\x0d\x02\x01\x03\x07\uffff\x01\x02\x02\uffff\x02\x02\x01\uffff"+
            "\x01\x04\x02\x02"
    };

    static readonly short[] DFA6_eot = DFA.UnpackEncodedString(DFA6_eotS);
    static readonly short[] DFA6_eof = DFA.UnpackEncodedString(DFA6_eofS);
    static readonly char[] DFA6_min = DFA.UnpackEncodedStringToUnsignedChars(DFA6_minS);
    static readonly char[] DFA6_max = DFA.UnpackEncodedStringToUnsignedChars(DFA6_maxS);
    static readonly short[] DFA6_accept = DFA.UnpackEncodedString(DFA6_acceptS);
    static readonly short[] DFA6_special = DFA.UnpackEncodedString(DFA6_specialS);
    static readonly short[][] DFA6_transition = DFA.UnpackEncodedStringArray(DFA6_transitionS);

    protected class DFA6 : DFA
    {
        public DFA6(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 6;
            this.eot = DFA6_eot;
            this.eof = DFA6_eof;
            this.min = DFA6_min;
            this.max = DFA6_max;
            this.accept = DFA6_accept;
            this.special = DFA6_special;
            this.transition = DFA6_transition;

        }

        override public string Description
        {
            get { return "25:18: ( businessRule )?"; }
        }

    }

    const string DFA12_eotS =
        "\x07\uffff";
    const string DFA12_eofS =
        "\x07\uffff";
    const string DFA12_minS =
        "\x01\x08\x01\uffff\x03\x08\x01\uffff\x01\x08";
    const string DFA12_maxS =
        "\x01\x2a\x01\uffff\x01\x2a\x01\x2b\x01\x08\x01\uffff\x01\x2b";
    const string DFA12_acceptS =
        "\x01\uffff\x01\x01\x03\uffff\x01\x02\x01\uffff";
    const string DFA12_specialS =
        "\x07\uffff}>";
    static readonly string[] DFA12_transitionS = {
            "\x05\x01\x01\uffff\x01\x01\x1b\uffff\x01\x02",
            "",
            "\x01\x03\x04\x01\x01\uffff\x01\x01\x1b\uffff\x01\x01",
            "\x01\x05\x04\uffff\x0d\x01\x01\x04\x0e\uffff\x03\x01",
            "\x01\x06",
            "",
            "\x01\x05\x04\uffff\x0d\x01\x01\x04\x0e\uffff\x03\x01"
    };

    static readonly short[] DFA12_eot = DFA.UnpackEncodedString(DFA12_eotS);
    static readonly short[] DFA12_eof = DFA.UnpackEncodedString(DFA12_eofS);
    static readonly char[] DFA12_min = DFA.UnpackEncodedStringToUnsignedChars(DFA12_minS);
    static readonly char[] DFA12_max = DFA.UnpackEncodedStringToUnsignedChars(DFA12_maxS);
    static readonly short[] DFA12_accept = DFA.UnpackEncodedString(DFA12_acceptS);
    static readonly short[] DFA12_special = DFA.UnpackEncodedString(DFA12_specialS);
    static readonly short[][] DFA12_transition = DFA.UnpackEncodedStringArray(DFA12_transitionS);

    protected class DFA12 : DFA
    {
        public DFA12(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 12;
            this.eot = DFA12_eot;
            this.eof = DFA12_eof;
            this.min = DFA12_min;
            this.max = DFA12_max;
            this.accept = DFA12_accept;
            this.special = DFA12_special;
            this.transition = DFA12_transition;

        }

        override public string Description
        {
            get { return "43:1: expression : ( conditionalExpression | lambda_expression );"; }
        }

    }

 

    public static readonly BitSet FOLLOW_rules_in_startEntity79 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_properties_in_startEntity82 = new BitSet(new ulong[]{0x0000000000000000UL});
    public static readonly BitSet FOLLOW_EOF_in_startEntity85 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_33_in_rules93 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_34_in_rules96 = new BitSet(new ulong[]{0x0000040800005F00UL});
    public static readonly BitSet FOLLOW_rule_in_rules99 = new BitSet(new ulong[]{0x0000040800005F00UL});
    public static readonly BitSet FOLLOW_35_in_rules102 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_36_in_properties112 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_34_in_properties115 = new BitSet(new ulong[]{0x0000000800000100UL});
    public static readonly BitSet FOLLOW_property_in_properties118 = new BitSet(new ulong[]{0x0000000800000100UL});
    public static readonly BitSet FOLLOW_35_in_properties121 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ruleType_in_rule131 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_businessRule_in_rule134 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_rule137 = new BitSet(new ulong[]{0x0000006400000000UL});
    public static readonly BitSet FOLLOW_37_in_rule140 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_rule142 = new BitSet(new ulong[]{0x0000006400000000UL});
    public static readonly BitSet FOLLOW_settings_in_rule146 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_38_in_rule149 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ID_in_property156 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_ID_in_property158 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_38_in_property160 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ID_in_ruleType168 = new BitSet(new ulong[]{0x0000008000000000UL});
    public static readonly BitSet FOLLOW_39_in_ruleType170 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ID_in_businessRule179 = new BitSet(new ulong[]{0x0000010004000000UL});
    public static readonly BitSet FOLLOW_CALL_in_businessRule182 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_ID_in_businessRule185 = new BitSet(new ulong[]{0x0000010004000000UL});
    public static readonly BitSet FOLLOW_40_in_businessRule189 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_34_in_settings197 = new BitSet(new ulong[]{0x0000002800000100UL});
    public static readonly BitSet FOLLOW_setting_in_settings200 = new BitSet(new ulong[]{0x0000002800000000UL});
    public static readonly BitSet FOLLOW_37_in_settings204 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_setting_in_settings207 = new BitSet(new ulong[]{0x0000002800000000UL});
    public static readonly BitSet FOLLOW_35_in_settings211 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ID_in_setting218 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_40_in_setting220 = new BitSet(new ulong[]{0x0000000000001F00UL});
    public static readonly BitSet FOLLOW_settingValue_in_setting222 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_settingValue0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_start263 = new BitSet(new ulong[]{0x0000000000000000UL});
    public static readonly BitSet FOLLOW_EOF_in_start265 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_expression276 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_lambda_expression_in_expression280 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditionalOrExpression_in_conditionalExpression294 = new BitSet(new ulong[]{0x0000020000000002UL});
    public static readonly BitSet FOLLOW_41_in_conditionalExpression298 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_conditionalExpression300 = new BitSet(new ulong[]{0x0000008000000000UL});
    public static readonly BitSet FOLLOW_39_in_conditionalExpression302 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_conditionalExpression304 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditionalAndExpression_in_conditionalOrExpression326 = new BitSet(new ulong[]{0x0000000000100002UL});
    public static readonly BitSet FOLLOW_OR_in_conditionalOrExpression330 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_conditionalAndExpression_in_conditionalOrExpression333 = new BitSet(new ulong[]{0x0000000000100002UL});
    public static readonly BitSet FOLLOW_equalityExpression_in_conditionalAndExpression355 = new BitSet(new ulong[]{0x0000000000200002UL});
    public static readonly BitSet FOLLOW_AND_in_conditionalAndExpression359 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_equalityExpression_in_conditionalAndExpression362 = new BitSet(new ulong[]{0x0000000000200002UL});
    public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression384 = new BitSet(new ulong[]{0x00000000000C0002UL});
    public static readonly BitSet FOLLOW_EQUALS_in_equalityExpression389 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_NOTEQUALS_in_equalityExpression394 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression398 = new BitSet(new ulong[]{0x00000000000C0002UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_relationalExpression420 = new BitSet(new ulong[]{0x0000000003C00002UL});
    public static readonly BitSet FOLLOW_LESSOREQUALS_in_relationalExpression425 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_GREATEROREQUALS_in_relationalExpression430 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_LESS_in_relationalExpression435 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_GREATER_in_relationalExpression440 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_relationalExpression444 = new BitSet(new ulong[]{0x0000000003C00002UL});
    public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression465 = new BitSet(new ulong[]{0x0000000000006002UL});
    public static readonly BitSet FOLLOW_PLUS_in_additiveExpression470 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_MINUS_in_additiveExpression473 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression477 = new BitSet(new ulong[]{0x0000000000006002UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression487 = new BitSet(new ulong[]{0x0000000000038002UL});
    public static readonly BitSet FOLLOW_MULTIPLY_in_multiplicativeExpression492 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_DIVIDE_in_multiplicativeExpression495 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_MODULO_in_multiplicativeExpression498 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression502 = new BitSet(new ulong[]{0x0000000000038002UL});
    public static readonly BitSet FOLLOW_MINUS_in_unaryExpression515 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression518 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_term_in_unaryExpression529 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_call_in_term536 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IntegerLiteral_in_term543 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DecimalLiteral_in_term550 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_StringLiteral_in_term557 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BooleanLiteral_in_term564 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_42_in_term571 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_term574 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_term576 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_method_in_call585 = new BitSet(new ulong[]{0x0000000004000002UL});
    public static readonly BitSet FOLLOW_CALL_in_call588 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_method_in_call591 = new BitSet(new ulong[]{0x0000000004000002UL});
    public static readonly BitSet FOLLOW_ID_in_method602 = new BitSet(new ulong[]{0x0000040000000002UL});
    public static readonly BitSet FOLLOW_42_in_method605 = new BitSet(new ulong[]{0x00000C2000005F00UL});
    public static readonly BitSet FOLLOW_expression_in_method609 = new BitSet(new ulong[]{0x0000082000000000UL});
    public static readonly BitSet FOLLOW_37_in_method613 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_expression_in_method618 = new BitSet(new ulong[]{0x0000082000000000UL});
    public static readonly BitSet FOLLOW_43_in_method622 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_anonymous_function_signature_in_lambda_expression646 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_lambda_expression648 = new BitSet(new ulong[]{0x0000040000005F00UL});
    public static readonly BitSet FOLLOW_expression_in_lambda_expression652 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_explicit_anonymous_function_signature_in_anonymous_function_signature672 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_42_in_explicit_anonymous_function_signature683 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_explicit_anonymous_function_parameter_list_in_explicit_anonymous_function_signature686 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_explicit_anonymous_function_signature688 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_explicit_anonymous_function_parameter_in_explicit_anonymous_function_parameter_list699 = new BitSet(new ulong[]{0x0000002000000002UL});
    public static readonly BitSet FOLLOW_37_in_explicit_anonymous_function_parameter_list702 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_explicit_anonymous_function_parameter_in_explicit_anonymous_function_parameter_list707 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typeName_in_explicit_anonymous_function_parameter717 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_ID_in_explicit_anonymous_function_parameter719 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ID_in_typeName738 = new BitSet(new ulong[]{0x0000000004000002UL});
    public static readonly BitSet FOLLOW_CALL_in_typeName742 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_ID_in_typeName746 = new BitSet(new ulong[]{0x0000000004000002UL});

}
}