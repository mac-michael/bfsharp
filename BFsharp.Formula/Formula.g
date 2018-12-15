grammar Formula;
options {
    output=AST;
    ASTLabelType=CommonTree; // type of $stat.tree ref etc...
    language=CSharp2;
}
tokens 
{
	METHOD;
	LAMBDA;
	PARAM;
	TYPENAME;
}

@parser::namespace { BFsharp.Formula }

@lexer::namespace { BFsharp.Formula }

startEntity: rules? properties? EOF;

rules	:	'rule'^ '{'^ rule* '}'^;
properties
	:	 'property'^ '{'^ property* '}'^;
	
rule	: ruleType? businessRule? conditionalExpression (',' conditionalExpression)* settings? ';'^;
property: ID ID ';'^;

ruleType:	ID ':'^;
businessRule
	:	ID ('.'^ ID)* '='^;

settings: '{'^ setting? (','^ setting)* '}'^;
setting: ID '=' settingValue;	

settingValue: ID | IntegerLiteral
	|   DecimalLiteral
	|   StringLiteral
	|   BooleanLiteral;

start:
	expression EOF!;

expression
	:	 conditionalExpression | lambda_expression;
// Conditions
conditionalExpression
    :   conditionalOrExpression ( '?' conditionalExpression ':' conditionalExpression )?
    ;

conditionalOrExpression
    :   conditionalAndExpression ( '||'^ conditionalAndExpression )*
    ;

conditionalAndExpression
    :   equalityExpression ( '&&'^ equalityExpression )*
    ;

equalityExpression
    :   relationalExpression ( ('=='^ | '!='^) relationalExpression )*
    ;

relationalExpression
    :   additiveExpression ( ('<='^ | '>='^ | '<'^ | '>'^) additiveExpression )*
    ;   

// Expression
additiveExpression:
	(multiplicativeExpression) (('+'^|'-'^) multiplicativeExpression)*;
multiplicativeExpression:
	(unaryExpression) (('*'^|'/'^|'%'^) unaryExpression)*;
unaryExpression:
    	'-'^ unaryExpression
    	|   term;
term:
	call
	|   IntegerLiteral
	|   DecimalLiteral
	|   StringLiteral
	|   BooleanLiteral
	|   '('! conditionalExpression ')'!;

call:	 method ('.'^ method)*;

method:	
	ID ('(' e+=expression? (',' e+= expression)* ')')? -> ^(METHOD ID $e*);

lambda_expression:
	s=anonymous_function_signature '=>' e=expression -> ^(LAMBDA $s $e);

anonymous_function_signature:
	explicit_anonymous_function_signature;	
//	explicit_anonymous_function_signature  todo


explicit_anonymous_function_signature:
	'('! explicit_anonymous_function_parameter_list ')'!;
//	| explicit_anonymous_function_parameter;
	
explicit_anonymous_function_parameter_list:
	explicit_anonymous_function_parameter (','!   explicit_anonymous_function_parameter)? ;
explicit_anonymous_function_parameter:
	typeName ID -> ^(PARAM typeName ID);

typeName: e=ID ( '.' e=ID )* -> ^(TYPENAME $e );

// Tokens
PLUS: 		'+';
MINUS: 		'-';
MULTIPLY: 	'*';
DIVIDE:		'/';
MODULO	:	'%';
EQUALS	: 	'==';
NOTEQUALS: 	'!=';
OR	:	'||';
AND	:	'&&';
LESS	:	 '<';
LESSOREQUALS:	 '<=';
GREATER	:	 '>';
GREATEROREQUALS: '>=';

CALL	:	 '.';

BooleanLiteral:
   'true'
    |   'false';
    
ID  :   ('a'..'z'|'A'..'Z')('a'..'z'|'A'..'Z'|'0'..'9')* ;

IntegerLiteral : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix? ;

DecimalLiteral:
    ('0'..'9')+ '.' ('0'..'9')* Exponent? FloatTypeSuffix?
    |   '.' ('0'..'9')+ Exponent? FloatTypeSuffix?
    |   ('0'..'9')+ Exponent FloatTypeSuffix?
    |   ('0'..'9')+ FloatTypeSuffix
    ;
fragment
IntegerTypeSuffix : ('l'|'L');

fragment
Exponent : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;

fragment
FloatTypeSuffix : ('f'|'F'|'d'|'D') ;

StringLiteral
    :  '"' ( ~('"') )* '"'
    ;

WS  :   (' '|'\t'|'\n'|'\r')+ {$channel=HIDDEN;};

COMMENT
    : '/*' .* '*/' {$channel=HIDDEN;}
    ;
LINE_COMMENT
    : '//' ~('\n'|'\r')* {$channel=HIDDEN;}
    ;
