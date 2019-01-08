using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
#region Comments
//Is there like a namespace class. I just want to be able to say namespace.GetExecutingNamespace() then get all types in namespace 
//Implement class like this below 
    //var poodle = Dog.Create("Poodle");
//poodle.Bark();

#endregion

namespace JobSite.Examples.ReplaceConstructorWithFactoryMethod
{

    public abstract class Dog
    {
        public Dog() { }


        public abstract void Bark();

        public static string Namespace => typeof(Dog).Namespace;

        public static Dog Create(string dogType) 
        {
            var dog = Assembly.GetExecutingAssembly().GetTypes().
                First(t => t.IsClass && t.Namespace == Namespace && t.Name == dogType);
 
            return (Dog)Activator.CreateInstance(dog);
        }

       
    }
}