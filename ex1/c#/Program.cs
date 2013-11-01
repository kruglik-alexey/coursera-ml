using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Generic;

namespace Ex1
{
	internal class Program
	{
		private static DenseMatrix x;
		private static DenseVector y;

		private static void Main(string[] args)
		{
			LoadData();
			var theta = GradientDescent();

		}

		private static DenseVector GradientDescent()
		{
			const int iterationCount = 1500;
			const double alpha = 0.01;
			var theta = new DenseVector(new double[] {0, 0});
			var costHistory = new List<double>(iterationCount);
			for (int i = 0; i < iterationCount; i++)
			{
				var newTheta = new DenseVector(theta.Count);
				for (int j = 0; j < theta.Count; j++)
				{
					var foo = (x*theta - y)*x.Column(j);
					newTheta[j] = theta[j] - (alpha/y.Count)*foo;
				}
				theta = newTheta;
				costHistory.Add(ComputeCost(theta));
				Console.WriteLine(costHistory.Last());
			}
			return theta;
		}

		private static void LoadData()
		{
			var culture = CultureInfo.CreateSpecificCulture("en-GB");
			List<string[]> lines = File.ReadLines(@"..\..\..\mlclass-ex1\ex1data1.txt").Select(l => l.Split(',')).ToList();
			x = new DenseMatrix(lines.Count, 2);
			y = new DenseVector(lines.Count);
			for (int i = 0; i < lines.Count; i++)
			{
				x[i, 0] = 1;
				x[i, 1] = Double.Parse(lines[i][0], culture);
				y[i] = Double.Parse(lines[i][1], culture);
			}
		}

		private static double ComputeCost(DenseVector theta)
		{
			DenseVector diff = x*theta - y;
			return diff.Sum(d => d*d) / (2 * x.RowCount);
		}
	}
}
