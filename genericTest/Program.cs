using System;

namespace genericTest
{
	public class Utils
	{
		public static Tuple<T,T> Swap<T>( T first,  T second) where T : struct
		{
			T temp = first;
			first = second;
			second = temp;

			return new Tuple<T, T>(first, second);
		}
	}

	public  class Test<T> 
		where T : struct 
	{
		private  T First { get; set; }
		public Test(T argument)
		{
			First = argument;
		}
		public T Add(T param2)
		{
			if (typeof(T) == typeof(int))
			{
				int firstValue = Convert.ToInt32(First);
				int secondValue = Convert.ToInt32(param2);
				int result = firstValue + secondValue;
				return (T)Convert.ChangeType(result, typeof(T));
			}
			else if (typeof(T) == typeof(double))
			{
				double firstValue = Convert.ToDouble(First);
				double secondValue = Convert.ToDouble(param2);
				double result = firstValue + secondValue;
				return (T)Convert.ChangeType(result, typeof(T));
			}
			// Obsłuż inne typy wartościowe według potrzeb

			throw new InvalidOperationException("Nieobsługiwany typ wartościowy.");
		}
	}


	internal delegate void MyClassCallbackDelegate(MyClass mc);
	internal class Program
	{
		
		static void Main(string[] args)
		{
			var test = new Test<double>(1);
			var reuslt = test.Add(2.1);
			int[] ints = { 1, 2, 3 };
			//var tuple = Utils.Swap<Test>(new Test(), new Test());

			////ints[0] = tuple.Item1;
			////ints[2] = tuple.Item2;
			//Console.WriteLine(string.Join(" ", ints));

			Console.WriteLine(reuslt);

			MyClass mc = new MyClass();
			MyClassCallbackDelegate mccd = MyClassCallback;

			mc.Callback(mccd);
		}

		static void MyClassCallback(MyClass mc)
		{
			Console.WriteLine("Użyto wywołania zwrotnego na MyClass!");
		}
	}

	class MyClass
	{
		public void Callback(MyClassCallbackDelegate mccd)
		{
			mccd(this);
		}
	}


}
