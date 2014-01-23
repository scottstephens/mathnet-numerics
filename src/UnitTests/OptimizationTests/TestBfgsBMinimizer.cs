using System;
using System.Threading;

using NUnit.Framework;

using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Optimization;

namespace MathNet.Numerics.UnitTests.OptimizationTests
{
	[TestFixture]
	public class TestBfgsBMinimizer
	{
		public TestBfgsBMinimizer ()
		{
		}

		[Test]
		public void FindMinimum_Rosenbrock_Easy()
		{
			var obj = new SimpleObjectiveFunction(RosenbrockFunction.Value, RosenbrockFunction.Gradient);
			var solver = new BfgsBMinimizer (1e-5, 1e-5, 1e-5, maximum_iterations: 1000);
			var lower_bound = new DenseVector(new double[]{ -5.0, -5.0 });
			var upper_bound = new DenseVector(new double[]{ 5.0, 5.0 });
			var initial_guess = new DenseVector(new double[] { 1.2, 1.2 });

			var result = solver.FindMinimum(obj, lower_bound, upper_bound, initial_guess);

			Assert.That(Math.Abs(result.MinimizingPoint[0] - 1.0), Is.LessThan(1e-3));
			Assert.That(Math.Abs(result.MinimizingPoint[1] - 1.0), Is.LessThan(1e-3));
		}

		[Test]
		public void FindMinimum_Rosenbrock_Hard()
		{
			var obj = new SimpleObjectiveFunction(RosenbrockFunction.Value, RosenbrockFunction.Gradient);
			var solver = new BfgsBMinimizer (1e-5, 1e-5, 1e-5, maximum_iterations: 1000);

			var lower_bound = new DenseVector(new double[]{ -5.0, -5.0 });
			var upper_bound = new DenseVector(new double[]{ 5.0, 5.0 });

			var initial_guess = new DenseVector (new double[]{ -1.2, 1.0 });

			var result = solver.FindMinimum(obj, lower_bound, upper_bound, initial_guess);

			Assert.That(Math.Abs(result.MinimizingPoint[0] - 1.0), Is.LessThan(1e-3));
			Assert.That(Math.Abs(result.MinimizingPoint[1] - 1.0), Is.LessThan(1e-3));
		}

		[Test]
		public void FindMinimum_Rosenbrock_Overton()
		{
			var obj = new SimpleObjectiveFunction(RosenbrockFunction.Value, RosenbrockFunction.Gradient);
			var solver = new BfgsBMinimizer (1e-5, 1e-5, 1e-5, maximum_iterations: 1000);

			var lower_bound = new DenseVector(new double[]{ -5.0, -5.0 });
			var upper_bound = new DenseVector(new double[]{ 5.0, 5.0 });
			var initial_guess = new DenseVector (new double[]{ -0.9, -0.5 });

			var result = solver.FindMinimum (obj, lower_bound, upper_bound, initial_guess);

			Assert.That(Math.Abs(result.MinimizingPoint[0] - 1.0), Is.LessThan(1e-3));
			Assert.That(Math.Abs(result.MinimizingPoint[1] - 1.0), Is.LessThan(1e-3));
		}

		[Test]
		public void FindMinimum_Rosenbrock_Easy_OneBoundary()
		{
			var obj = new SimpleObjectiveFunction(RosenbrockFunction.Value, RosenbrockFunction.Gradient);
			var solver = new BfgsBMinimizer (1e-5, 1e-5, 1e-5, maximum_iterations: 1000);
			var lower_bound = new DenseVector(new double[]{ 1.0, -5.0 });
			var upper_bound = new DenseVector(new double[]{ 5.0, 5.0 });
			var initial_guess = new DenseVector(new double[] { 1.2, 1.2 });

			var result = solver.FindMinimum(obj, lower_bound, upper_bound, initial_guess);

			Assert.That(Math.Abs(result.MinimizingPoint[0] - 1.0), Is.LessThan(1e-3));
			Assert.That(Math.Abs(result.MinimizingPoint[1] - 1.0), Is.LessThan(1e-3));
		}

		[Test]
		public void FindMinimum_Rosenbrock_Easy_TwoBoundaries()
		{
			var obj = new SimpleObjectiveFunction(RosenbrockFunction.Value, RosenbrockFunction.Gradient);
			var solver = new BfgsBMinimizer (1e-5, 1e-5, 1e-5, maximum_iterations: 1000);
			var lower_bound = new DenseVector(new double[]{ 1.0, 1.0 });
			var upper_bound = new DenseVector(new double[]{ 5.0, 5.0 });
			var initial_guess = new DenseVector(new double[] { 1.2, 1.2 });

			var result = solver.FindMinimum(obj, lower_bound, upper_bound, initial_guess);

			Assert.That(Math.Abs(result.MinimizingPoint[0] - 1.0), Is.LessThan(1e-3));
			Assert.That(Math.Abs(result.MinimizingPoint[1] - 1.0), Is.LessThan(1e-3));
		}
	}
}

