# SqlComputeExercise V1.0

This app runs all the asked tasks.\
\
I choosed IOC architecture in order to easily add/replace and test computing modules, following the SOLID recommendations.\
\
Compute : Contains all computing classes (Linq, Lambda, Sql, Fibo, etc). Each class implements ICompute interface, so adding new computing class is easier.\
ConsoleTools : Contains all I/O classes + string parsing class (interpretor)\
Data : Contains EF core management class + DB Models\
Exceptions : Contains all created exceptions\
Menu : Contains the menu manager\

Unit Testing \
Documentation \
Better Exceptions management \
Better Entity Framework management (DB file personalisation, throwing/ handling exceptions) \
Better first menu interpretation \
Config file for IOT Container \
Config file for strings + translation to uniformize all the app \
SQL Queries optimization \
Fibonnaci optimisation (+ handling numbers > 45) \
Refactoring  \
etc..
