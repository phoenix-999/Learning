using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass);
            DisplayMethods(type);
            DisplayTypeInfo(type);

            Assembly assembly = GetAssembly("./AppSettingsTest.exe");//Позднее связывание
            if (assembly == null) return;

            assembly.PrintAssemblyData();
            object instance = GetInstance(assembly, "AppSettingsTest.BusinessLogicEvents"); //Создание экземпляра
            InvokeMethod(instance, "InitializeBusinessLogicEventHandlers", null);//Вызов метода

            #region Создание экземпляра с применением динамической типизации

            Type businessLogicEventsType = assembly.GetType("AppSettingsTest.BusinessLogicEvents");
            dynamic businessLogicEvents = Activator.CreateInstance(businessLogicEventsType); 
            try
            {
                businessLogicEvents.InitializeBusinessLogicEventHandlers(); //Исключение. экземпляр является object
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion



        }

        static void DisplayMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (MethodInfo m in methods)
            {
                Console.WriteLine(m.Name);
            }
        }

        static void DisplayTypeInfo(Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();

            IEnumerable<MethodInfo> methods = typeInfo.DeclaredMethods;
            methods.PrintTypeData();

            IEnumerable<FieldInfo> fileds = typeInfo.DeclaredFields;
            fileds.PrintTypeData();

            IEnumerable<PropertyInfo> propertys = typeInfo.DeclaredProperties;
            propertys.PrintTypeData();

            IEnumerable<EventInfo> events = typeInfo.DeclaredEvents;
            events.PrintTypeData();

            IEnumerable<ConstructorInfo> constructors = typeInfo.DeclaredConstructors;
            constructors.PrintTypeData();

            IEnumerable<Type> interfaces = typeInfo.ImplementedInterfaces;
            interfaces.PrintTypeData();

        }

        static Assembly GetAssembly(string assemblyFullName)
        {
            Console.WriteLine(new string('-', 30));
            Assembly assembly = null;

            try
            {
                assembly = Assembly.LoadFrom(assemblyFullName);
                Console.WriteLine("Сборка {0} успешно загружена", assembly.FullName);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return assembly;
        }

        static object GetInstance(Assembly assembly, string typeName)
        {
            object instance = null;
            try
            {
                Type type = assembly.GetType(typeName);
                instance = Activator.CreateInstance(type); //Создание экземпляра
                Console.WriteLine("Тип {0} успешно создан", instance.GetType());
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return instance;
        }

        static Type InvokeMethod(object instance, string methodName, params object[] arguments)
        {
            Type type = instance.GetType();
            Type returnType = null;
            try
            {
                MethodInfo method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (method.ReturnType != null)
                {
                    returnType = method.Invoke(instance, arguments) as Type;
                    MethodBody methodBody = method.GetMethodBody();
                    byte[] msil = methodBody.GetILAsByteArray();
                    Console.WriteLine("Тело метода (MSIL):");
                    for (int i = 0; i < msil.Length; i++)
                    {
                        Console.Write("{0}", msil[i]);
                    }
                    Console.WriteLine();
                }
                else
                {
                    method.Invoke(instance, arguments);
                }
                Console.WriteLine("Метод {0} успешно отработал.", method.Name);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Элементы массива parameters не соответствуют сигнатуре метода или конструктора,отраженного этим экземпляром");
            }
            catch(TargetInvocationException)
            {
                Console.WriteLine("Вызванный метод или конструктор выдает исключение. -или-Текущий экземпляр является классом System.Reflection.Emit.DynamicMethod, который содержит непроверяемыйкод.См. подраздел \"Проверка\" в разделе примечаний к System.Reflection.Emit.DynamicMethod.");
            }
            catch (TargetParameterCountException)
            {
                Console.WriteLine("Массив parameters не имеет правильного числа аргументов.");
            }
            catch (MethodAccessException)
            {
                Console.WriteLine("В .NET для приложений Магазина Windows или переносимой библиотеке классов вместоэтого перехватите исключение базового класса System.MemberAccessException.Вызывающийобъект не имеет разрешения на выполнение метода или конструктора, представляемыйтекущим экземпляром.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnType;
        }
    }

    static class Printer
    {
        public static void PrintTypeData(this IEnumerable<MemberInfo> members)
        {
            Console.WriteLine(new string('-', 30));
            foreach(MemberInfo mi in members)
            {
                Console.WriteLine("Type member: {0}, name member: {1}", mi.MemberType, mi.Name);
            }

            
        }

        public static void PrintAssemblyData(this Assembly assembly)
        {
            Console.WriteLine(new string('-', 30));
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine("Type: {0}, name: {1}", type.GetType(), type.Name);
            }
        }
    }

    

    interface IA
    {
        void MethodA();
    }
    class MyClass : IA
    {
        public int field1;
        private int field2;

        public MyClass(int i)
        {
            field2 = i;
        }

        public void MethodA() { }
        private void MethodPrivate() { }

        private static void MethodStatic() { }
    }


    
}

