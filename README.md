# StaticDotNet.ParameterValidation

StaticDotNet.ParameterValidation is a fluent library to help validate parameters.

## Supported Platforms
* .NET Core (.NET Standard 1.0 and higher)
* 4.5.1 .NET Framework

Please let me know other platforms you would like support for.

## Installation

Installation is done via NuGet:

    Install-Package StaticDotNet.ParameterValidation

## Usage

To validate any parameter, you start use the `Parameter.Validate` method. Because this is a fluent library, you can chain multiple checks together. Intellisense will also only show the validation methods which are appropriate for the parameter type.

***NOTE: There is a known issue in Visual Studio 2015 currently where intellisense doesn't show up for the Contains validation method. The code will compile when using the method. <a href="https://github.com/dotnet/roslyn/issues/11619">https://github.com/dotnet/roslyn/issues/11619</a>***

### Add the Using Statement

```csharp
using StaticDotNet.ParameterValidation
```

### Add the Validation

```csharp
public void MyMethod( string parameter )
{
	Parameter.Validate( parameter, nameof( parameter ) )
		.IsNotNull()
		.IsNotWhiteSpace();
}
```

## Handling Nulls

Null parameter values are generally ignored unless specifically stated by the validation method.  This allows you to have validation on parameters which are not required.

```csharp
public void MyMethod( string parameter )
{
	Parameter.Validate( parameter, nameof( parameter ) )
		.IsNotEmpty()
		.IsNotWhiteSpace();

	// parameter can be null in this case.
	// But if it does have a value, it must not be empty or white space.
}
```

## Exception Messages
You can specify your own exception message. Each one has an overload which allows you to specify your own exception message.

```csharp
public void MyMethod( string parameter )
{
	Parameter.Validate( parameter, nameof( parameter ) )
		.IsNotNull( myExceptionMessage );
}
```

## Performance
The library has some validation methods which have output parameters.  The reason being is so your code an avoid making extra calls when it doesn't need to.  Here are a couple of examples:

* **IsType** - Outputs the parameter value casted to the Type specified.
* **Match** - Outputs the `System.Text.RegularExpressions.Match`.


## Extensibility
Extending the library to add your own validation is simple and easy.  All you need to create an extension method on `StaticDotNet.ParameterValidation.ParameterValidator<TParameter>`. The validator has `Name` and `Value` proprties to give you access to the parameter information.  Unless the type you want to validate against is a concrete type that will not have anything inherit from it, you should use a type constraint instead of passing that type into `TParameter`. You also want to make sure it returns `StaticDotNet.ParameterValidation.ParameterValidator<TParameter>` to allow chaining.

```csharp
public static ParameterValidator<TParameter> IsCorrect( this ParameterValidator<TParameter> validator )
	where TParameter : MyClass
{
	///Validate the parameter here. The value will be inside validator.Value.

	return validator;
}
```

## Supported Validation Methods
Here is a list of the current validation methods. Please let me know what additional validation checks you would like provided with the library.

### General
Validation for all parameters.

* IsNotNull
* IsNull
* IsEqualTo
* IsNotEqualTo
* IsType
* When
* ThrowIf

### String
Validation for `string` parameters.

* IsEqualTo( bool ignoreCase ) ( >= .NetStandard 1.3 )
  * Additional overload to ignore case.
* IsEqualNotTo( bool ignoreCase ) ( >= .NetStandard 1.3 )
  * Additional overload to ignore case.
* IsNotEmpty
* IsEmpty
* IsNotNullOrEmpty
* IsNotWhiteSpace
* IsNotNullOrWhiteSpace
* HasLength
* HasMaxLength
* HasMinLength
* HasLengthBetween
* Contains( string value )
* StartsWith
* EndsWith
* Match

### Type
Validation for `System.Type`

* IsEqualTo
  * Additional overload allowing generic parameter.
* IsAssignableTo
* IsClass
* IsInterface

### IComparable
Validation for `System.IComparable` parameters.

* IsGreaterThan
* IsGreaterThanOrEqualTo
* IsLessThan
* IsLessThanOrEqualTo
* IsBetween

### IEnumerable
Validation for `System.IEnumerable' and 'System.Collections.Generic.IEnumerable<T>` parameters.

* IsNotEmpty
* IsEmpty
* IsNotNullOrEmpty
* Contains
