using System;

namespace ConsoleApp2
{
    class S2259_Test
    {
        public string Prop { get; set; }
        //            ^^^^ CS8618: Non-nullable property 'Prop' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        public static string GetProp(S2259_Test t1, S2259_Test t2)
        {
            if (t1 != null)
                return t1.Prop;

            if (t2 != null)
                return t1.Prop;
            //         ^^ CS8602: Dereference of a possibly null reference.

            return string.Empty;
        }

        static void Main()
        {
            var prop = GetProp(null, new S2259_Test { Prop = "hey" });
            //                 ^^^^ CS8625: Cannot convert null literal to non-nullable reference type.
            Console.WriteLine(prop);
        }
    }
}
