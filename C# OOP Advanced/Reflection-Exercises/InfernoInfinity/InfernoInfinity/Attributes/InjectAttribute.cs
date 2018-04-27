using System;

namespace InfernoInfinity.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {
    }
}