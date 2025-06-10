namespace Lyt.DependencyHiker.Reflector.Structures;

public sealed record class MethodDescriptor(
    bool IsStatic, 
    Type ReturnType, 
    List<Type> ParameterTypes,
    List<Type> DependantTypes, 
    string Name = "");