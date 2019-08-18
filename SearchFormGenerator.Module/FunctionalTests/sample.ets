;#DropDB SearchFormGeneratorEasyTest

#Application SearchFormGenerator.Win
#Application SearchFormGenerator.Web
#IfDef SearchFormGenerator.Win

*Action About...
 
*Action OK

#EndIf

#IfDef SearchFormGenerator.Web
!Action Navigation(My Details)
#EndIf
