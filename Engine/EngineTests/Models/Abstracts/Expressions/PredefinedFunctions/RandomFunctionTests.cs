using Engine.Logic.Expressions.PredefinedFunctions;

using NUnit.Framework;

using Assert = NUnit.Framework.Assert;

namespace EngineTests.Models.Abstracts.Expressions.PredefinedFunctions;

[TestFixture()]
public class RandomFunctionTests
{
    [Test()]
    public void ParseDefinitionTest_ContinuousArgs()
    {
        var test1 = " random(1, 10.5) ";
        var rf1 = new RandomFunction();
        rf1.ParseDefinition(test1);

        Assert.IsTrue(rf1.IsValid);
        Assert.IsFalse(rf1.IsDiscrete);
        Assert.AreEqual(1, rf1.Operand1);
        Assert.AreEqual(10.5, rf1.Operand2);
    }

    [Test()]
    public void ParseDefinitionTest_DiscreteArgs()
    {
        var test1 = " random(5,60) ";
        var rf1 = new RandomFunction();
        rf1.ParseDefinition(test1);

        Assert.IsTrue(rf1.IsValid);
        Assert.IsTrue(rf1.IsDiscrete);
        Assert.AreEqual(5, rf1.Operand1);
        Assert.AreEqual(60, rf1.Operand2);
    }

    [Test()]
    public void ParseDefinitionTest_Failed()
    {
        var tests = new string?[] {
            null,
            "random(5-60.5)",
            " raaaandom(7-60) ",
            "(4,5)",
            "",
            "random(1,2",
            "random(a,b)",
            "random(55,1.1",
            "random 55,1.1)",
            "random[1,444]",
            "random(1,2,3,4,5)"
        };
        foreach (var test in tests)
        {
            var rf1 = new RandomFunction();
            rf1.ParseDefinition(test);
            Assert.IsFalse(rf1.IsValid);
        }
    }
}