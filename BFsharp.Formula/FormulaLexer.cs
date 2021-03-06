// $ANTLR 3.1.2 D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g 2018-06-10 19:27:46

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


namespace  BFsharp.Formula 
{
public partial class FormulaLexer : Lexer {
    public const int EOF = -1;
    public const int T__33 = 33;
    public const int T__34 = 34;
    public const int T__35 = 35;
    public const int T__36 = 36;
    public const int T__37 = 37;
    public const int T__38 = 38;
    public const int T__39 = 39;
    public const int T__40 = 40;
    public const int T__41 = 41;
    public const int T__42 = 42;
    public const int T__43 = 43;
    public const int T__44 = 44;
    public const int AND = 4;
    public const int BooleanLiteral = 5;
    public const int CALL = 6;
    public const int COMMENT = 7;
    public const int DecimalLiteral = 8;
    public const int DIVIDE = 9;
    public const int EQUALS = 10;
    public const int Exponent = 11;
    public const int FloatTypeSuffix = 12;
    public const int GREATER = 13;
    public const int GREATEROREQUALS = 14;
    public const int ID = 15;
    public const int IntegerLiteral = 16;
    public const int IntegerTypeSuffix = 17;
    public const int LAMBDA = 18;
    public const int LESS = 19;
    public const int LESSOREQUALS = 20;
    public const int LINE_COMMENT = 21;
    public const int METHOD = 22;
    public const int MINUS = 23;
    public const int MODULO = 24;
    public const int MULTIPLY = 25;
    public const int NOTEQUALS = 26;
    public const int OR = 27;
    public const int PARAM = 28;
    public const int PLUS = 29;
    public const int StringLiteral = 30;
    public const int TYPENAME = 31;
    public const int WS = 32;

    // delegates
    // delegators

    public FormulaLexer() 
    {
		InitializeCyclicDFAs();
    }
    public FormulaLexer(ICharStream input)
		: this(input, null) {
    }
    public FormulaLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g";} 
    }

    // $ANTLR start "T__33"
    public void mT__33() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__33;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:9:9: ( '(' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:9:9: '('
            {
            	Match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__33"

    // $ANTLR start "T__34"
    public void mT__34() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__34;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:10:9: ( ')' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:10:9: ')'
            {
            	Match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__34"

    // $ANTLR start "T__35"
    public void mT__35() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__35;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:11:9: ( ',' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:11:9: ','
            {
            	Match(','); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__35"

    // $ANTLR start "T__36"
    public void mT__36() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__36;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:12:9: ( ':' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:12:9: ':'
            {
            	Match(':'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__36"

    // $ANTLR start "T__37"
    public void mT__37() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__37;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:13:9: ( ';' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:13:9: ';'
            {
            	Match(';'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__37"

    // $ANTLR start "T__38"
    public void mT__38() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__38;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:14:9: ( '?' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:14:9: '?'
            {
            	Match('?'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__38"

    // $ANTLR start "T__39"
    public void mT__39() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__39;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:15:9: ( '{' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:15:9: '{'
            {
            	Match('{'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__39"

    // $ANTLR start "T__40"
    public void mT__40() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__40;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:16:9: ( '}' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:16:9: '}'
            {
            	Match('}'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__40"

    // $ANTLR start "T__41"
    public void mT__41() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__41;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:17:9: ( '=' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:17:9: '='
            {
            	Match('='); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__41"

    // $ANTLR start "T__42"
    public void mT__42() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__42;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:18:9: ( '=>' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:18:9: '=>'
            {
            	Match("=>"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__42"

    // $ANTLR start "T__43"
    public void mT__43() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__43;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:19:9: ( 'property' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:19:9: 'property'
            {
            	Match("property"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__43"

    // $ANTLR start "T__44"
    public void mT__44() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__44;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:20:9: ( 'rule' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:20:9: 'rule'
            {
            	Match("rule"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__44"

    // $ANTLR start "PLUS"
    public void mPLUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PLUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:107:9: ( '+' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:107:9: '+'
            {
            	Match('+'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PLUS"

    // $ANTLR start "MINUS"
    public void mMINUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MINUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:108:10: ( '-' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:108:10: '-'
            {
            	Match('-'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MINUS"

    // $ANTLR start "MULTIPLY"
    public void mMULTIPLY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MULTIPLY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:109:12: ( '*' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:109:12: '*'
            {
            	Match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MULTIPLY"

    // $ANTLR start "DIVIDE"
    public void mDIVIDE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DIVIDE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:110:10: ( '/' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:110:10: '/'
            {
            	Match('/'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIVIDE"

    // $ANTLR start "MODULO"
    public void mMODULO() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MODULO;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:111:10: ( '%' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:111:10: '%'
            {
            	Match('%'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MODULO"

    // $ANTLR start "EQUALS"
    public void mEQUALS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EQUALS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:112:11: ( '==' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:112:11: '=='
            {
            	Match("=="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EQUALS"

    // $ANTLR start "NOTEQUALS"
    public void mNOTEQUALS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NOTEQUALS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:113:13: ( '!=' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:113:13: '!='
            {
            	Match("!="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NOTEQUALS"

    // $ANTLR start "OR"
    public void mOR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = OR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:114:6: ( '||' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:114:6: '||'
            {
            	Match("||"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "OR"

    // $ANTLR start "AND"
    public void mAND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = AND;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:115:7: ( '&&' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:115:7: '&&'
            {
            	Match("&&"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "AND"

    // $ANTLR start "LESS"
    public void mLESS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LESS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:116:9: ( '<' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:116:9: '<'
            {
            	Match('<'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LESS"

    // $ANTLR start "LESSOREQUALS"
    public void mLESSOREQUALS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LESSOREQUALS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:117:16: ( '<=' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:117:16: '<='
            {
            	Match("<="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LESSOREQUALS"

    // $ANTLR start "GREATER"
    public void mGREATER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = GREATER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:118:12: ( '>' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:118:12: '>'
            {
            	Match('>'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "GREATER"

    // $ANTLR start "GREATEROREQUALS"
    public void mGREATEROREQUALS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = GREATEROREQUALS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:119:18: ( '>=' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:119:18: '>='
            {
            	Match(">="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "GREATEROREQUALS"

    // $ANTLR start "CALL"
    public void mCALL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CALL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:121:9: ( '.' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:121:9: '.'
            {
            	Match('.'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CALL"

    // $ANTLR start "BooleanLiteral"
    public void mBooleanLiteral() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = BooleanLiteral;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:124:4: ( 'true' | 'false' )
            int alt1 = 2;
            int LA1_0 = input.LA(1);

            if ( (LA1_0 == 't') )
            {
                alt1 = 1;
            }
            else if ( (LA1_0 == 'f') )
            {
                alt1 = 2;
            }
            else 
            {
                NoViableAltException nvae_d1s0 =
                    new NoViableAltException("", 1, 0, input);

                throw nvae_d1s0;
            }
            switch (alt1) 
            {
                case 1 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:124:4: 'true'
                    {
                    	Match("true"); 


                    }
                    break;
                case 2 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:125:9: 'false'
                    {
                    	Match("false"); 


                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "BooleanLiteral"

    // $ANTLR start "ID"
    public void mID() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ID;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:127:9: ( ( 'a' .. 'z' | 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' )* )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:127:9: ( 'a' .. 'z' | 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' )*
            {
            	if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:127:28: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= '0' && LA2_0 <= '9') || (LA2_0 >= 'A' && LA2_0 <= 'Z') || (LA2_0 >= 'a' && LA2_0 <= 'z')) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ID"

    // $ANTLR start "IntegerLiteral"
    public void mIntegerLiteral() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IntegerLiteral;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:129:18: ( ( '0' | '1' .. '9' ( '0' .. '9' )* ) ( IntegerTypeSuffix )? )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:129:18: ( '0' | '1' .. '9' ( '0' .. '9' )* ) ( IntegerTypeSuffix )?
            {
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:129:18: ( '0' | '1' .. '9' ( '0' .. '9' )* )
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);

            	if ( (LA4_0 == '0') )
            	{
            	    alt4 = 1;
            	}
            	else if ( ((LA4_0 >= '1' && LA4_0 <= '9')) )
            	{
            	    alt4 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d4s0 =
            	        new NoViableAltException("", 4, 0, input);

            	    throw nvae_d4s0;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:129:19: '0'
            	        {
            	        	Match('0'); 

            	        }
            	        break;
            	    case 2 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:129:25: '1' .. '9' ( '0' .. '9' )*
            	        {
            	        	MatchRange('1','9'); 
            	        	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:129:34: ( '0' .. '9' )*
            	        	do 
            	        	{
            	        	    int alt3 = 2;
            	        	    int LA3_0 = input.LA(1);

            	        	    if ( ((LA3_0 >= '0' && LA3_0 <= '9')) )
            	        	    {
            	        	        alt3 = 1;
            	        	    }


            	        	    switch (alt3) 
            	        		{
            	        			case 1 :
            	        			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            	        			    {
            	        			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) 
            	        			    	{
            	        			    	    input.Consume();

            	        			    	}
            	        			    	else 
            	        			    	{
            	        			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        			    	    Recover(mse);
            	        			    	    throw mse;}


            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop3;
            	        	    }
            	        	} while (true);

            	        	loop3:
            	        		;	// Stops C# compiler whining that label 'loop3' has no statements


            	        }
            	        break;

            	}

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:129:45: ( IntegerTypeSuffix )?
            	int alt5 = 2;
            	int LA5_0 = input.LA(1);

            	if ( (LA5_0 == 'L' || LA5_0 == 'l') )
            	{
            	    alt5 = 1;
            	}
            	switch (alt5) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            	        {
            	        	if ( input.LA(1) == 'L' || input.LA(1) == 'l' ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}


            	        }
            	        break;

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IntegerLiteral"

    // $ANTLR start "DecimalLiteral"
    public void mDecimalLiteral() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DecimalLiteral;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:132:5: ( ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( Exponent )? ( FloatTypeSuffix )? | '.' ( '0' .. '9' )+ ( Exponent )? ( FloatTypeSuffix )? | ( '0' .. '9' )+ Exponent ( FloatTypeSuffix )? | ( '0' .. '9' )+ FloatTypeSuffix )
            int alt16 = 4;
            alt16 = dfa16.Predict(input);
            switch (alt16) 
            {
                case 1 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:132:5: ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( Exponent )? ( FloatTypeSuffix )?
                    {
                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:132:5: ( '0' .. '9' )+
                    	int cnt6 = 0;
                    	do 
                    	{
                    	    int alt6 = 2;
                    	    int LA6_0 = input.LA(1);

                    	    if ( ((LA6_0 >= '0' && LA6_0 <= '9')) )
                    	    {
                    	        alt6 = 1;
                    	    }


                    	    switch (alt6) 
                    		{
                    			case 1 :
                    			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
                    			    {
                    			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) 
                    			    	{
                    			    	    input.Consume();

                    			    	}
                    			    	else 
                    			    	{
                    			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    			    	    Recover(mse);
                    			    	    throw mse;}


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt6 >= 1 ) goto loop6;
                    		            EarlyExitException eee6 =
                    		                new EarlyExitException(6, input);
                    		            throw eee6;
                    	    }
                    	    cnt6++;
                    	} while (true);

                    	loop6:
                    		;	// Stops C# compiler whining that label 'loop6' has no statements

                    	Match('.'); 
                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:132:21: ( '0' .. '9' )*
                    	do 
                    	{
                    	    int alt7 = 2;
                    	    int LA7_0 = input.LA(1);

                    	    if ( ((LA7_0 >= '0' && LA7_0 <= '9')) )
                    	    {
                    	        alt7 = 1;
                    	    }


                    	    switch (alt7) 
                    		{
                    			case 1 :
                    			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
                    			    {
                    			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) 
                    			    	{
                    			    	    input.Consume();

                    			    	}
                    			    	else 
                    			    	{
                    			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    			    	    Recover(mse);
                    			    	    throw mse;}


                    			    }
                    			    break;

                    			default:
                    			    goto loop7;
                    	    }
                    	} while (true);

                    	loop7:
                    		;	// Stops C# compiler whining that label 'loop7' has no statements

                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:132:33: ( Exponent )?
                    	int alt8 = 2;
                    	int LA8_0 = input.LA(1);

                    	if ( (LA8_0 == 'E' || LA8_0 == 'e') )
                    	{
                    	    alt8 = 1;
                    	}
                    	switch (alt8) 
                    	{
                    	    case 1 :
                    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:132:0: Exponent
                    	        {
                    	        	mExponent(); 

                    	        }
                    	        break;

                    	}

                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:132:43: ( FloatTypeSuffix )?
                    	int alt9 = 2;
                    	int LA9_0 = input.LA(1);

                    	if ( (LA9_0 == 'D' || LA9_0 == 'F' || LA9_0 == 'd' || LA9_0 == 'f') )
                    	{
                    	    alt9 = 1;
                    	}
                    	switch (alt9) 
                    	{
                    	    case 1 :
                    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
                    	        {
                    	        	if ( input.LA(1) == 'D' || input.LA(1) == 'F' || input.LA(1) == 'd' || input.LA(1) == 'f' ) 
                    	        	{
                    	        	    input.Consume();

                    	        	}
                    	        	else 
                    	        	{
                    	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	        	    Recover(mse);
                    	        	    throw mse;}


                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:133:9: '.' ( '0' .. '9' )+ ( Exponent )? ( FloatTypeSuffix )?
                    {
                    	Match('.'); 
                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:133:13: ( '0' .. '9' )+
                    	int cnt10 = 0;
                    	do 
                    	{
                    	    int alt10 = 2;
                    	    int LA10_0 = input.LA(1);

                    	    if ( ((LA10_0 >= '0' && LA10_0 <= '9')) )
                    	    {
                    	        alt10 = 1;
                    	    }


                    	    switch (alt10) 
                    		{
                    			case 1 :
                    			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
                    			    {
                    			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) 
                    			    	{
                    			    	    input.Consume();

                    			    	}
                    			    	else 
                    			    	{
                    			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    			    	    Recover(mse);
                    			    	    throw mse;}


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt10 >= 1 ) goto loop10;
                    		            EarlyExitException eee10 =
                    		                new EarlyExitException(10, input);
                    		            throw eee10;
                    	    }
                    	    cnt10++;
                    	} while (true);

                    	loop10:
                    		;	// Stops C# compiler whining that label 'loop10' has no statements

                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:133:25: ( Exponent )?
                    	int alt11 = 2;
                    	int LA11_0 = input.LA(1);

                    	if ( (LA11_0 == 'E' || LA11_0 == 'e') )
                    	{
                    	    alt11 = 1;
                    	}
                    	switch (alt11) 
                    	{
                    	    case 1 :
                    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:133:0: Exponent
                    	        {
                    	        	mExponent(); 

                    	        }
                    	        break;

                    	}

                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:133:35: ( FloatTypeSuffix )?
                    	int alt12 = 2;
                    	int LA12_0 = input.LA(1);

                    	if ( (LA12_0 == 'D' || LA12_0 == 'F' || LA12_0 == 'd' || LA12_0 == 'f') )
                    	{
                    	    alt12 = 1;
                    	}
                    	switch (alt12) 
                    	{
                    	    case 1 :
                    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
                    	        {
                    	        	if ( input.LA(1) == 'D' || input.LA(1) == 'F' || input.LA(1) == 'd' || input.LA(1) == 'f' ) 
                    	        	{
                    	        	    input.Consume();

                    	        	}
                    	        	else 
                    	        	{
                    	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	        	    Recover(mse);
                    	        	    throw mse;}


                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 3 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:134:9: ( '0' .. '9' )+ Exponent ( FloatTypeSuffix )?
                    {
                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:134:9: ( '0' .. '9' )+
                    	int cnt13 = 0;
                    	do 
                    	{
                    	    int alt13 = 2;
                    	    int LA13_0 = input.LA(1);

                    	    if ( ((LA13_0 >= '0' && LA13_0 <= '9')) )
                    	    {
                    	        alt13 = 1;
                    	    }


                    	    switch (alt13) 
                    		{
                    			case 1 :
                    			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
                    			    {
                    			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) 
                    			    	{
                    			    	    input.Consume();

                    			    	}
                    			    	else 
                    			    	{
                    			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    			    	    Recover(mse);
                    			    	    throw mse;}


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt13 >= 1 ) goto loop13;
                    		            EarlyExitException eee13 =
                    		                new EarlyExitException(13, input);
                    		            throw eee13;
                    	    }
                    	    cnt13++;
                    	} while (true);

                    	loop13:
                    		;	// Stops C# compiler whining that label 'loop13' has no statements

                    	mExponent(); 
                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:134:30: ( FloatTypeSuffix )?
                    	int alt14 = 2;
                    	int LA14_0 = input.LA(1);

                    	if ( (LA14_0 == 'D' || LA14_0 == 'F' || LA14_0 == 'd' || LA14_0 == 'f') )
                    	{
                    	    alt14 = 1;
                    	}
                    	switch (alt14) 
                    	{
                    	    case 1 :
                    	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
                    	        {
                    	        	if ( input.LA(1) == 'D' || input.LA(1) == 'F' || input.LA(1) == 'd' || input.LA(1) == 'f' ) 
                    	        	{
                    	        	    input.Consume();

                    	        	}
                    	        	else 
                    	        	{
                    	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	        	    Recover(mse);
                    	        	    throw mse;}


                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 4 :
                    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:135:9: ( '0' .. '9' )+ FloatTypeSuffix
                    {
                    	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:135:9: ( '0' .. '9' )+
                    	int cnt15 = 0;
                    	do 
                    	{
                    	    int alt15 = 2;
                    	    int LA15_0 = input.LA(1);

                    	    if ( ((LA15_0 >= '0' && LA15_0 <= '9')) )
                    	    {
                    	        alt15 = 1;
                    	    }


                    	    switch (alt15) 
                    		{
                    			case 1 :
                    			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
                    			    {
                    			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) 
                    			    	{
                    			    	    input.Consume();

                    			    	}
                    			    	else 
                    			    	{
                    			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    			    	    Recover(mse);
                    			    	    throw mse;}


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt15 >= 1 ) goto loop15;
                    		            EarlyExitException eee15 =
                    		                new EarlyExitException(15, input);
                    		            throw eee15;
                    	    }
                    	    cnt15++;
                    	} while (true);

                    	loop15:
                    		;	// Stops C# compiler whining that label 'loop15' has no statements

                    	mFloatTypeSuffix(); 

                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DecimalLiteral"

    // $ANTLR start "IntegerTypeSuffix"
    public void mIntegerTypeSuffix() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:139:21: ( ( 'l' | 'L' ) )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            {
            	if ( input.LA(1) == 'L' || input.LA(1) == 'l' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "IntegerTypeSuffix"

    // $ANTLR start "Exponent"
    public void mExponent() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:142:12: ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:142:12: ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+
            {
            	if ( input.LA(1) == 'E' || input.LA(1) == 'e' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:142:22: ( '+' | '-' )?
            	int alt17 = 2;
            	int LA17_0 = input.LA(1);

            	if ( (LA17_0 == '+' || LA17_0 == '-') )
            	{
            	    alt17 = 1;
            	}
            	switch (alt17) 
            	{
            	    case 1 :
            	        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            	        {
            	        	if ( input.LA(1) == '+' || input.LA(1) == '-' ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}


            	        }
            	        break;

            	}

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:142:33: ( '0' .. '9' )+
            	int cnt18 = 0;
            	do 
            	{
            	    int alt18 = 2;
            	    int LA18_0 = input.LA(1);

            	    if ( ((LA18_0 >= '0' && LA18_0 <= '9')) )
            	    {
            	        alt18 = 1;
            	    }


            	    switch (alt18) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt18 >= 1 ) goto loop18;
            		            EarlyExitException eee18 =
            		                new EarlyExitException(18, input);
            		            throw eee18;
            	    }
            	    cnt18++;
            	} while (true);

            	loop18:
            		;	// Stops C# compiler whining that label 'loop18' has no statements


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Exponent"

    // $ANTLR start "FloatTypeSuffix"
    public void mFloatTypeSuffix() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:145:19: ( ( 'f' | 'F' | 'd' | 'D' ) )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            {
            	if ( input.LA(1) == 'D' || input.LA(1) == 'F' || input.LA(1) == 'd' || input.LA(1) == 'f' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "FloatTypeSuffix"

    // $ANTLR start "StringLiteral"
    public void mStringLiteral() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = StringLiteral;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:147:8: ( '\"' (~ ( '\"' ) )* '\"' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:147:8: '\"' (~ ( '\"' ) )* '\"'
            {
            	Match('\"'); 
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:147:12: (~ ( '\"' ) )*
            	do 
            	{
            	    int alt19 = 2;
            	    int LA19_0 = input.LA(1);

            	    if ( ((LA19_0 >= '\u0000' && LA19_0 <= '!') || (LA19_0 >= '#' && LA19_0 <= '\uFFFF')) )
            	    {
            	        alt19 = 1;
            	    }


            	    switch (alt19) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '!') || (input.LA(1) >= '#' && input.LA(1) <= '\uFFFF') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop19;
            	    }
            	} while (true);

            	loop19:
            		;	// Stops C# compiler whining that label 'loop19' has no statements

            	Match('\"'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "StringLiteral"

    // $ANTLR start "WS"
    public void mWS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:150:9: ( ( ' ' | '\\t' | '\\n' | '\\r' )+ )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:150:9: ( ' ' | '\\t' | '\\n' | '\\r' )+
            {
            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:150:9: ( ' ' | '\\t' | '\\n' | '\\r' )+
            	int cnt20 = 0;
            	do 
            	{
            	    int alt20 = 2;
            	    int LA20_0 = input.LA(1);

            	    if ( ((LA20_0 >= '\t' && LA20_0 <= '\n') || LA20_0 == '\r' || LA20_0 == ' ') )
            	    {
            	        alt20 = 1;
            	    }


            	    switch (alt20) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            			    {
            			    	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || input.LA(1) == '\r' || input.LA(1) == ' ' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt20 >= 1 ) goto loop20;
            		            EarlyExitException eee20 =
            		                new EarlyExitException(20, input);
            		            throw eee20;
            	    }
            	    cnt20++;
            	} while (true);

            	loop20:
            		;	// Stops C# compiler whining that label 'loop20' has no statements

            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WS"

    // $ANTLR start "COMMENT"
    public void mCOMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:153:7: ( '/*' ( . )* '*/' )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:153:7: '/*' ( . )* '*/'
            {
            	Match("/*"); 

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:153:12: ( . )*
            	do 
            	{
            	    int alt21 = 2;
            	    int LA21_0 = input.LA(1);

            	    if ( (LA21_0 == '*') )
            	    {
            	        int LA21_1 = input.LA(2);

            	        if ( (LA21_1 == '/') )
            	        {
            	            alt21 = 2;
            	        }
            	        else if ( ((LA21_1 >= '\u0000' && LA21_1 <= '.') || (LA21_1 >= '0' && LA21_1 <= '\uFFFF')) )
            	        {
            	            alt21 = 1;
            	        }


            	    }
            	    else if ( ((LA21_0 >= '\u0000' && LA21_0 <= ')') || (LA21_0 >= '+' && LA21_0 <= '\uFFFF')) )
            	    {
            	        alt21 = 1;
            	    }


            	    switch (alt21) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:153:0: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop21;
            	    }
            	} while (true);

            	loop21:
            		;	// Stops C# compiler whining that label 'loop21' has no statements

            	Match("*/"); 

            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMENT"

    // $ANTLR start "LINE_COMMENT"
    public void mLINE_COMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LINE_COMMENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:156:7: ( '//' (~ ( '\\n' | '\\r' ) )* )
            // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:156:7: '//' (~ ( '\\n' | '\\r' ) )*
            {
            	Match("//"); 

            	// D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:156:12: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt22 = 2;
            	    int LA22_0 = input.LA(1);

            	    if ( ((LA22_0 >= '\u0000' && LA22_0 <= '\t') || (LA22_0 >= '\u000B' && LA22_0 <= '\f') || (LA22_0 >= '\u000E' && LA22_0 <= '\uFFFF')) )
            	    {
            	        alt22 = 1;
            	    }


            	    switch (alt22) 
            		{
            			case 1 :
            			    // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\uFFFF') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop22;
            	    }
            	} while (true);

            	loop22:
            		;	// Stops C# compiler whining that label 'loop22' has no statements

            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LINE_COMMENT"

    override public void mTokens() // throws RecognitionException 
    {
        // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:10: ( T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | PLUS | MINUS | MULTIPLY | DIVIDE | MODULO | EQUALS | NOTEQUALS | OR | AND | LESS | LESSOREQUALS | GREATER | GREATEROREQUALS | CALL | BooleanLiteral | ID | IntegerLiteral | DecimalLiteral | StringLiteral | WS | COMMENT | LINE_COMMENT )
        int alt23 = 34;
        alt23 = dfa23.Predict(input);
        switch (alt23) 
        {
            case 1 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:10: T__33
                {
                	mT__33(); 

                }
                break;
            case 2 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:16: T__34
                {
                	mT__34(); 

                }
                break;
            case 3 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:22: T__35
                {
                	mT__35(); 

                }
                break;
            case 4 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:28: T__36
                {
                	mT__36(); 

                }
                break;
            case 5 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:34: T__37
                {
                	mT__37(); 

                }
                break;
            case 6 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:40: T__38
                {
                	mT__38(); 

                }
                break;
            case 7 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:46: T__39
                {
                	mT__39(); 

                }
                break;
            case 8 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:52: T__40
                {
                	mT__40(); 

                }
                break;
            case 9 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:58: T__41
                {
                	mT__41(); 

                }
                break;
            case 10 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:64: T__42
                {
                	mT__42(); 

                }
                break;
            case 11 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:70: T__43
                {
                	mT__43(); 

                }
                break;
            case 12 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:76: T__44
                {
                	mT__44(); 

                }
                break;
            case 13 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:82: PLUS
                {
                	mPLUS(); 

                }
                break;
            case 14 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:87: MINUS
                {
                	mMINUS(); 

                }
                break;
            case 15 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:93: MULTIPLY
                {
                	mMULTIPLY(); 

                }
                break;
            case 16 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:102: DIVIDE
                {
                	mDIVIDE(); 

                }
                break;
            case 17 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:109: MODULO
                {
                	mMODULO(); 

                }
                break;
            case 18 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:116: EQUALS
                {
                	mEQUALS(); 

                }
                break;
            case 19 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:123: NOTEQUALS
                {
                	mNOTEQUALS(); 

                }
                break;
            case 20 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:133: OR
                {
                	mOR(); 

                }
                break;
            case 21 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:136: AND
                {
                	mAND(); 

                }
                break;
            case 22 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:140: LESS
                {
                	mLESS(); 

                }
                break;
            case 23 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:145: LESSOREQUALS
                {
                	mLESSOREQUALS(); 

                }
                break;
            case 24 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:158: GREATER
                {
                	mGREATER(); 

                }
                break;
            case 25 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:166: GREATEROREQUALS
                {
                	mGREATEROREQUALS(); 

                }
                break;
            case 26 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:182: CALL
                {
                	mCALL(); 

                }
                break;
            case 27 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:187: BooleanLiteral
                {
                	mBooleanLiteral(); 

                }
                break;
            case 28 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:202: ID
                {
                	mID(); 

                }
                break;
            case 29 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:205: IntegerLiteral
                {
                	mIntegerLiteral(); 

                }
                break;
            case 30 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:220: DecimalLiteral
                {
                	mDecimalLiteral(); 

                }
                break;
            case 31 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:235: StringLiteral
                {
                	mStringLiteral(); 

                }
                break;
            case 32 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:249: WS
                {
                	mWS(); 

                }
                break;
            case 33 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:252: COMMENT
                {
                	mCOMMENT(); 

                }
                break;
            case 34 :
                // D:\\My projects\\BFsharp\\BFsharp.Formula\\Formula.g:1:260: LINE_COMMENT
                {
                	mLINE_COMMENT(); 

                }
                break;

        }

    }


    protected DFA16 dfa16;
    protected DFA23 dfa23;
	private void InitializeCyclicDFAs()
	{
	    this.dfa16 = new DFA16(this);
	    this.dfa23 = new DFA23(this);


	}

    const string DFA16_eotS =
        "\x6\xFFFF";
    const string DFA16_eofS =
        "\x6\xFFFF";
    const string DFA16_minS =
        "\x2\x2E\x4\xFFFF";
    const string DFA16_maxS =
        "\x1\x39\x1\x66\x4\xFFFF";
    const string DFA16_acceptS =
        "\x2\xFFFF\x1\x2\x1\x1\x1\x3\x1\x4";
    const string DFA16_specialS =
        "\x6\xFFFF}>";
    static readonly string[] DFA16_transitionS = {
            "\x1\x2\x1\xFFFF\xA\x1",
            "\x1\x3\x1\xFFFF\xA\x1\xA\xFFFF\x1\x5\x1\x4\x1\x5\x1D\xFFFF\x1"+
            "\x5\x1\x4\x1\x5",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA16_eot = DFA.UnpackEncodedString(DFA16_eotS);
    static readonly short[] DFA16_eof = DFA.UnpackEncodedString(DFA16_eofS);
    static readonly char[] DFA16_min = DFA.UnpackEncodedStringToUnsignedChars(DFA16_minS);
    static readonly char[] DFA16_max = DFA.UnpackEncodedStringToUnsignedChars(DFA16_maxS);
    static readonly short[] DFA16_accept = DFA.UnpackEncodedString(DFA16_acceptS);
    static readonly short[] DFA16_special = DFA.UnpackEncodedString(DFA16_specialS);
    static readonly short[][] DFA16_transition = DFA.UnpackEncodedStringArray(DFA16_transitionS);

    protected class DFA16 : DFA
    {
        public DFA16(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 16;
            this.eot = DFA16_eot;
            this.eof = DFA16_eof;
            this.min = DFA16_min;
            this.max = DFA16_max;
            this.accept = DFA16_accept;
            this.special = DFA16_special;
            this.transition = DFA16_transition;

        }

        override public string Description
        {
            get { return "131:0: DecimalLiteral : ( ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( Exponent )? ( FloatTypeSuffix )? | '.' ( '0' .. '9' )+ ( Exponent )? ( FloatTypeSuffix )? | ( '0' .. '9' )+ Exponent ( FloatTypeSuffix )? | ( '0' .. '9' )+ FloatTypeSuffix );"; }
        }

    }

    const string DFA23_eotS =
        "\x9\xFFFF\x1\x20\x2\x19\x3\xFFFF\x1\x25\x4\xFFFF\x1\x27\x1\x29\x1"+
        "\x2A\x2\x19\x1\xFFFF\x2\x2E\x5\xFFFF\x2\x19\x9\xFFFF\x2\x19\x1\xFFFF"+
        "\x1\x2E\x5\x19\x1\x39\x1\x3A\x2\x19\x2\xFFFF\x1\x3A\x2\x19\x1\x3F"+
        "\x1\xFFFF";
    const string DFA23_eofS =
        "\x40\xFFFF";
    const string DFA23_minS =
        "\x1\x9\x8\xFFFF\x1\x3D\x1\x72\x1\x75\x3\xFFFF\x1\x2A\x4\xFFFF\x2"+
        "\x3D\x1\x30\x1\x72\x1\x61\x1\xFFFF\x2\x2E\x5\xFFFF\x1\x6F\x1\x6C"+
        "\x9\xFFFF\x1\x75\x1\x6C\x1\xFFFF\x1\x2E\x1\x70\x2\x65\x1\x73\x1"+
        "\x65\x2\x30\x1\x65\x1\x72\x2\xFFFF\x1\x30\x1\x74\x1\x79\x1\x30\x1"+
        "\xFFFF";
    const string DFA23_maxS =
        "\x1\x7D\x8\xFFFF\x1\x3E\x1\x72\x1\x75\x3\xFFFF\x1\x2F\x4\xFFFF\x2"+
        "\x3D\x1\x39\x1\x72\x1\x61\x1\xFFFF\x2\x66\x5\xFFFF\x1\x6F\x1\x6C"+
        "\x9\xFFFF\x1\x75\x1\x6C\x1\xFFFF\x1\x66\x1\x70\x2\x65\x1\x73\x1"+
        "\x65\x2\x7A\x1\x65\x1\x72\x2\xFFFF\x1\x7A\x1\x74\x1\x79\x1\x7A\x1"+
        "\xFFFF";
    const string DFA23_acceptS =
        "\x1\xFFFF\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x3\xFFFF"+
        "\x1\xD\x1\xE\x1\xF\x1\xFFFF\x1\x11\x1\x13\x1\x14\x1\x15\x5\xFFFF"+
        "\x1\x1C\x2\xFFFF\x1\x1F\x1\x20\x1\xA\x1\x12\x1\x9\x2\xFFFF\x1\x21"+
        "\x1\x22\x1\x10\x1\x17\x1\x16\x1\x19\x1\x18\x1\x1A\x1\x1E\x2\xFFFF"+
        "\x1\x1D\xA\xFFFF\x1\xC\x1\x1B\x4\xFFFF\x1\xB";
    const string DFA23_specialS =
        "\x40\xFFFF}>";
    static readonly string[] DFA23_transitionS = {
            "\x2\x1D\x2\xFFFF\x1\x1D\x12\xFFFF\x1\x1D\x1\x11\x1\x1C\x2\xFFFF"+
            "\x1\x10\x1\x13\x1\xFFFF\x1\x1\x1\x2\x1\xE\x1\xC\x1\x3\x1\xD"+
            "\x1\x16\x1\xF\x1\x1A\x9\x1B\x1\x4\x1\x5\x1\x14\x1\x9\x1\x15"+
            "\x1\x6\x1\xFFFF\x1A\x19\x6\xFFFF\x5\x19\x1\x18\x9\x19\x1\xA"+
            "\x1\x19\x1\xB\x1\x19\x1\x17\x6\x19\x1\x7\x1\x12\x1\x8",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x1\x1F\x1\x1E",
            "\x1\x21",
            "\x1\x22",
            "",
            "",
            "",
            "\x1\x23\x4\xFFFF\x1\x24",
            "",
            "",
            "",
            "",
            "\x1\x26",
            "\x1\x28",
            "\xA\x2B",
            "\x1\x2C",
            "\x1\x2D",
            "",
            "\x1\x2B\x1\xFFFF\xA\x2B\xA\xFFFF\x3\x2B\x1D\xFFFF\x3\x2B",
            "\x1\x2B\x1\xFFFF\xA\x2F\xA\xFFFF\x3\x2B\x1D\xFFFF\x3\x2B",
            "",
            "",
            "",
            "",
            "",
            "\x1\x30",
            "\x1\x31",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x1\x32",
            "\x1\x33",
            "",
            "\x1\x2B\x1\xFFFF\xA\x2F\xA\xFFFF\x3\x2B\x1D\xFFFF\x3\x2B",
            "\x1\x34",
            "\x1\x35",
            "\x1\x36",
            "\x1\x37",
            "\x1\x38",
            "\xA\x19\x7\xFFFF\x1A\x19\x6\xFFFF\x1A\x19",
            "\xA\x19\x7\xFFFF\x1A\x19\x6\xFFFF\x1A\x19",
            "\x1\x3B",
            "\x1\x3C",
            "",
            "",
            "\xA\x19\x7\xFFFF\x1A\x19\x6\xFFFF\x1A\x19",
            "\x1\x3D",
            "\x1\x3E",
            "\xA\x19\x7\xFFFF\x1A\x19\x6\xFFFF\x1A\x19",
            ""
    };

    static readonly short[] DFA23_eot = DFA.UnpackEncodedString(DFA23_eotS);
    static readonly short[] DFA23_eof = DFA.UnpackEncodedString(DFA23_eofS);
    static readonly char[] DFA23_min = DFA.UnpackEncodedStringToUnsignedChars(DFA23_minS);
    static readonly char[] DFA23_max = DFA.UnpackEncodedStringToUnsignedChars(DFA23_maxS);
    static readonly short[] DFA23_accept = DFA.UnpackEncodedString(DFA23_acceptS);
    static readonly short[] DFA23_special = DFA.UnpackEncodedString(DFA23_specialS);
    static readonly short[][] DFA23_transition = DFA.UnpackEncodedStringArray(DFA23_transitionS);

    protected class DFA23 : DFA
    {
        public DFA23(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 23;
            this.eot = DFA23_eot;
            this.eof = DFA23_eof;
            this.min = DFA23_min;
            this.max = DFA23_max;
            this.accept = DFA23_accept;
            this.special = DFA23_special;
            this.transition = DFA23_transition;

        }

        override public string Description
        {
            get { return "1:0: Tokens : ( T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | PLUS | MINUS | MULTIPLY | DIVIDE | MODULO | EQUALS | NOTEQUALS | OR | AND | LESS | LESSOREQUALS | GREATER | GREATEROREQUALS | CALL | BooleanLiteral | ID | IntegerLiteral | DecimalLiteral | StringLiteral | WS | COMMENT | LINE_COMMENT );"; }
        }

    }

 
    
}
}