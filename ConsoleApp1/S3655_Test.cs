namespace ConsoleApp1
{
    public class S3655_Test
    {
        public S3655_Test()
        {
            DoStuff();
        }


        private void DoStuff()
        {
            ValueParser vp = new ValueParser();

            DateTime? aDate;

            aDate = vp.ConvertToDateTime();

            Console.WriteLine(aDate.Value);
        }

    }
    public class ValueParser
    {
        DateTime? periodStartDate;
        public ValueParser()
        {
        }

        public DateTime? ConvertToDateTime()
        {
            periodStartDate = DateTime.Now;
            return null; // periodStartDate.Value;
        }

    }
}
