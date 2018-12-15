lexer grammar Formula;
options {
  language=CSharp2;

}

@namespace { BFsharp.Formula }

T__33 : '(' ;
T__34 : ')' ;
T__35 : ',' ;
T__36 : ':' ;
T__37 : ';' ;
T__38 : '?' ;
T__39 : '{' ;
T__40 : '}' ;
T__41 : '=' ;
T__42 : '=>' ;
T__43 : 'property' ;
T__44 : 'rule' ;

// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 107
PLUS: 		'+';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 108
MINUS: 		'-';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 109
MULTIPLY: 	'*';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 110
DIVIDE:		'/';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 111
MODULO	:	'%';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 112
EQUALS	: 	'==';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 113
NOTEQUALS: 	'!=';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 114
OR	:	'||';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 115
AND	:	'&&';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 116
LESS	:	 '<';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 117
LESSOREQUALS:	 '<=';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 118
GREATER	:	 '>';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 119
GREATEROREQUALS: '>=';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 121
CALL	:	 '.';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 123
BooleanLiteral:
   'true'
    |   'false';// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 127
ID  :   ('a'..'z'|'A'..'Z')('a'..'z'|'A'..'Z'|'0'..'9')* ;// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 129
IntegerLiteral : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix? ;// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 131
DecimalLiteral:
    ('0'..'9')+ '.' ('0'..'9')* Exponent? FloatTypeSuffix?
    |   '.' ('0'..'9')+ Exponent? FloatTypeSuffix?
    |   ('0'..'9')+ Exponent FloatTypeSuffix?
    |   ('0'..'9')+ FloatTypeSuffix
    ;// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 138
fragment
IntegerTypeSuffix : ('l'|'L');// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 141
fragment
Exponent : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 144
fragment
FloatTypeSuffix : ('f'|'F'|'d'|'D') ;// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 146
StringLiteral
    :  '"' ( ~('"') )* '"'
    ;// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 150
WS  :   (' '|'\t'|'\n'|'\r')+ {$channel=HIDDEN;};// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 152
COMMENT
    : '/*' .* '*/' {$channel=HIDDEN;}
    ;// $ANTLR src "D:\My projects\BFsharp\BFsharp.Formula\Formula.g" 155
LINE_COMMENT
    : '//' ~('\n'|'\r')* {$channel=HIDDEN;}
    ;