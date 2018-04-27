using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Spy
{
    public string StealFieldInfo(string name, params string[] namesOfField)
    {
        var sb = new StringBuilder();
        var fields = Type.GetType(name).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        sb.AppendLine($"Class under investigation: {name}");
        var instance = Activator.CreateInstance(Type.GetType(name));

        foreach (var field in fields)
        {
            if (namesOfField.Contains(field.Name))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        var type = Type.GetType(className);

        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        var NonPublicProperties = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        var PublicProperties = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var prop in NonPublicProperties.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{prop.Name} have to be public!");
        }

        foreach (var prop in PublicProperties.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{prop.Name} have to be private!");

        }
        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var type = Type.GetType(className);

        var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        var sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        var sb = new StringBuilder();

        var type = Type.GetType(className);

        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        var getters = methods.Where(m => m.Name.StartsWith("get"));

        var setters = methods.Where(m => m.Name.StartsWith("set"));

        foreach (var getter in getters)
        {
            var returnType = getter.ReturnType;

            sb.AppendLine($"{getter.Name} will return {returnType.FullName}");
        }

        foreach (var setter in setters)
        {
            var paramType = setter.GetParameters().First().ParameterType;

            sb.AppendLine($"{setter.Name} will set field of {paramType.FullName}");
        }

        return sb.ToString().Trim();
    }
}
