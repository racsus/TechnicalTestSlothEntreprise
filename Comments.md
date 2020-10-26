# Oscar's comments
I have found the following antipatterns in the old code: 
* Code repeated to load CompanyDataRequest data (Solved using Factory classes)
* Anemic Model. All the logic is inside the service class, for a small application could be a good and quick solution(Transaction Script architecture), but for a big and rich logic application is not a good solution. (Solved moving the logic to the Product models)
* Some SOLID principles have been broken, like Single Responsability Principle(The method SubmitApplicationFor has more than 1 responsability) or Open Closed Principle(If we'd need to add extra logic we'd need to modify this method and we could break something).  (Solved applying polymorphism OOP)