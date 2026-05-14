#Binary Tree Assignment with MVC Web application design.

The was based on a university assignment where the task was to implement a console project of a binary search tree with some sorting algorithm.  The project has been extended to use a website as a front end and apply a MVC architecture.  It also was an opportunity to practice a strategy design pattern.

This is a ASP.NET CORE MVC Web Application.  The FrontEnd is provided as a Website which is rendered on the server(SSR).  When the user inputs some text to the website, the HTML forms
will send a GET request to the backend application.  The Controller class will pass the inputed data to a coordinator object and a service object, which will use a Strategy Design Pattern to find a selected search method and sort method. The texts is processed, words are found and counted and put in a List(keyvalueList).  This is passed to the chosen sorting method and returned to a partial view, index view and ultimatly the layout view. The user should see a full table of words and their count.

There is a plan to measure the performance of each search and sort and display the performance in some widgets. 

#Further actions

-Sort the items that share the same count by the name A-Z 

-add other ways to sort - by A-Z, Z-A, Count low to high, high to low. (the quicksort is set to be low to high)

- add the performance measuring and display features.

- extend to accept much largers texts or multiple types of texts.


#Reflections 

Its a very over engineered website! but i will continue to explore how to make use of the features more appropiatlty. 


