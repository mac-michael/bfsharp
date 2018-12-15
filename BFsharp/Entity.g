grammar Entity;
options {
    output=AST;
    language=CSharp2;
}


startEntity: rule* EOF;


rule	: LINE settings ';';

settings 
	: '{'^ ID'}'^;


ID  :   ('a'..'z'|'A'..'Z'|'@')('a'..'z'|'A'..'Z'|'0'..'9')* ;
WS  :   (' '|'\t'|'\n'|'\r')+ {$channel=HIDDEN;};
LINE    :  'rule ' ^ ~('{')*;
