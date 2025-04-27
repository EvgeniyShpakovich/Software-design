# Принципи програмування в проєкті

## SOLID
### S — Single Responsibility Principle (SRP)
+ Клас [Product](./Clases/Product.cs) має одну відповідальність — зберігання даних про продукт: назва, ціна та категорія.
+ Клас [Warehouse](./Clases/Warehouse.cs) відповідає лише за управління запасами продуктів (додавання, звіти).
+ Клас [Reporting](./Clases/Reporting.cs) відповідає за обробку та генерування звітів.
+ Клас [Money](./Clases/Money.cs) відповідає за операції з грошима (додавання, вирахування).

### O — Open/Closed Principle (OCP)
+ Клас [Product](./Clases/Product.cs) та [Warehouse](./Clases/Warehouse.cs) відкриті для розширення (можна додавати нові категорії продуктів або товари), але закриті для змін, оскільки додавання нових продуктів не потребує змін в коді цих класів.

### I — Interface Segregation Principle (ISP)
+ Класи [Product](./Clases/Product.cs) та [Money](./Clases/Money.cs) розділені на чіткі інтерфейси: [IProduct](./Clases/IProduct.cs) для продуктів і [IMoney](./Clases/IMoney.cs) для грошей. Це дозволяє кожному класу мати тільки ті методи, які йому дійсно потрібні, замість великого загального інтерфейсу.

### D — Dependency Inversion Principle (DIP)
+ В класі [Reporting](./Clases/Reporting.cs) є залежність від класу [Warehouse](./Clases/Warehouse.cs), але ця залежність інжектується через конструктор, що дозволяє заміняти або підміняти реалізацію [Warehouse](./Clases/Warehouse.cs) без змін в класі [Reporting](./Clases/Reporting.cs).

## YAGNI (You Ain’t Gonna Need It)
+ У коді немає зайвих методів чи класів, які не виконують реальної функціональності.

## DRY (Don't Repeat Yourself)
+ Всі класи, що працюють з [грошима](./Clases/Money.cs) чи [продуктами](./Clases/Product.cs), не повторюють код. Кожен клас має чітке призначення та відповідальність.
+ Використання [AddProduct](./Clases/Warehouse.cs#L5-L8) та [RegisterTransaction](./Clases/Reporting.cs#L5-L11) дозволяє централізовано додавати продукти та реєструвати транзакції без дублювання логіки.

## Program to Interfaces, not Implementations
+ У коді всі залежності виражені через інтерфейси, зокрема: [IProduct](./Clases/IProduct.cs) та [IMoney](./Clases/IMoney.cs). Це забезпечує можливість змінювати реалізацію без внесення змін у класи, які використовують ці інтерфейси. Наприклад, клас [Reporting](./Clases/Reporting.cs) працює з інтерфейсом [IProduct](./Clases/IProduct.cs), що дозволяє йому оперувати будь-якими реалізаціями продуктів, які відповідають цьому інтерфейсу.

