using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_to_the_Future
{
    static class Universe
    {
        public static List<Car> AllCarsOfFuture = new List<Car>();
        public static Thread ImpruveUniverse = new Thread(AddCarOfFuture);
        public static void GetUniverse()
        {
            ImpruveUniverse.Start();
            Car car = new Car();     
            car.Registr();
            AllCarsOfFuture.Add(car);
        }
        public static void AddCarOfFuture()
        {
            while (true)
            {
                Thread.Sleep(3000);
                if (new Random().Next(20) == 0)
                {
                    List<Car> AllCarsOfFuture2 = new List<Car>();

                    foreach (var val in AllCarsOfFuture)
                    {
                        if (val.protection.Procent <= 50)
                        {
                            AllCarsOfFuture2.Add(val);
                        }
                    }

                    if (AllCarsOfFuture2.Count > 0)
                    {
                        AllCarsOfFuture.Remove(AllCarsOfFuture2[new Random().Next(0, AllCarsOfFuture2.Count)]);
                    }
                    continue;
                }

                if (new Random().Next(15) != 0)
                {
                    continue;
                }








                //Генератор Имя Фамилли

                string[] baseNames = {
            "Александр","Сергей","Дмитрий","Андрей","Алексей","Иван","Михаил","Николай","Егор","Владимир",
            "Павел","Олег","Юрий","Виктор","Максим","Константин","Валерий","Вячеслав","Георгий","Антон",
            "Игорь","Роман","Станислав","Борис","Фёдор","Григорий","Леонид","Кирилл","Виталий"
            // … добавь до 300
        };

                string[] baseSurnames = {
            "Иванов","Петров","Сидоров","Смирнов","Кузнецов","Попов","Васильев","Новиков","Фёдоров","Морозов",
            "Волков","Алексеев","Лебедев","Семенов","Егоров","Никитин","Захаров","Тимофеев","Орлов","Андреев",
            "Макаров","Гаврилов","Козлов","Степанов","Мельников","Тарасов","Белов","Комаров","Куликов","Карпов"
            // … добавь до 300
        };

                List<string> expandedNames = new List<string>();
                List<string> expandedSurnames = new List<string>();

                // Генерация имён с вариантами
                foreach (var name in baseNames)
                {
                    expandedNames.Add(name);
                    
                }

                // Генерация фамилий с суффиксами
                foreach (var surname in baseSurnames)
                {
                    expandedSurnames.Add(surname);
                    expandedSurnames.Add(surname + "ский");
                    expandedSurnames.Add(surname + "цов");
                    expandedSurnames.Add(surname + "енко");
                    expandedSurnames.Add(surname + "ич");
                }

                Random rnd = new Random();

                string name2 = expandedNames[rnd.Next(expandedNames.Count)];
                string surname2 = expandedSurnames[rnd.Next(expandedSurnames.Count)];




                Car car = new Car() { Name = name2, LastName = surname2 };

                if (rnd.Next(0, 15) == 0)
                {
                    car.Rank = new FuturePolice();
                }
                else
                {
                    car.Rank = new FuturePerson();
                }
                    AllCarsOfFuture.Add(car);
            }
        }    
    }
}
