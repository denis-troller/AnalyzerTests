// See https://aka.ms/new-console-template for more information
using AnalyzerTests;

Console.WriteLine("Hello, World!");

#pragma warning disable CS0168
int I;
#pragma warning restore CS0168

var apiKey = "aio_XFKJb9078YvbkljV0879vhjkj7G4";
var sonar = "b6aacfcf7358cc0afb651e3fd7607df7814af792";

C.Get(typeof(string), "a");
C.Get2(typeof(string), "a");
C.GetValue(typeof(string), "a");

using (var f = new FileStream("aaa", FileMode.Open))
{
    var c = new C();
    c.ReadStream(f);
}

void DoStuff()
{
    int a;
}