# NullableClass
Helper classes and analyzer to avoid usage of null in class types, for C#.

## Motivation

We all know about the so-called “billion-dollar mistake”: the existence of a `null` value for reference types. Among other languages, C# adopted it, and it made sense at the time, but working around all the code and trying to avoid `NullReferenceException`s becomes a real problem.

Fortunately, there's a solution to this problem. Other languages have the concept of a `Maybe` or `Optional` type, where the lack of a value is explicitly stated and statically validated by the compiler.

This package provides a wrapper class `NullableOf<T>` that behaves similar to `Nullable<T>`, but for classes instead of structs.

## Installation

There's two packages to install:

* **[NullableClass](https://www.nuget.org/packages/NullableClass)**: The main classes.
* **[NullableClass.Analyzer](https://www.nuget.org/packages/NullableClass.Analyzer)**: A Roslyn analyzer to forbid the use of a native `null`.

## Usage

You first import the namespace:

    using NullableClass;

And then you can use NullableOf<T> in the following ways:

    NullableOf<string> withValue = "Hello, World!";
    NullableOf<string> empty = null;
    
    string fine = "OK!";
    string error = null; // With the analyzer installed, this will be marked as an error and won't compile.
    
    // Same semantics as Nullable<T> for structs
    var nullableString = default(NullableOf<string>);
    nullableString.HasValue; // Boolean
    nullableString.Value; // Throws exception if there's no value
    nullableString.GetValueOrDefault(); // Gets default value - see next section
    
You can also use it on properties and fields (but remember to give them default values):

    public class Person
    {
        public string FirstName { get; set; } = "";
        public NullableOf<string> MiddleName { get; set; }
        // With the analyzer, this won't compile
        public string LastName { get; set; }
        
        private string userId = "";
        private NullableOf<string> roles;
    }

### Default values and arrays

Something that always comes up when discussing non-nullable classes is arrays. How do you create arrays, what values do you use?

Well, this library also includes a helper class `Default<T>`. It lets you define a default value for a given class, and create an array full of default values.

Just like this:

    Default<string>.Set(() => ""); // This one is already provided by the library
    Default<Person>.Set(() => new Person("John", "Smith"));
    
    nullableString.GetValueOrDefault(); // Uses the definition above internally
    
    Person[] arrayOfPeople = Default<Person>.NewArray(10);
    
    // You can create arrays with values just fine
    var coolKids = new Person[]
    {
        new Person("Sour", "Cream"),
        new Person("Jenny", "Pizza"),
        new Person("Buck", "Dewey"),
    };
    
    // This is forbidden by the analyzer
    var emptyPeople = new Person[5];
    
    // This is fine
    var emptyNullPeople = new NullableOf<Person>[5];

Of course, the `NewArray` helper method will create a new array and then iterate it and create a new class for each item. Take this into account when creating large arrays so it doesn't affect performance.

You can set the default value in a static constructor, so you guarantee it already exists whenever you need it:

    public class Foo
    {
        static Foo()
        {
            Default<Foo>.Set(() => new Foo());
        }
    }

### LINQ magic

The library includes extensions for both `Nullable<T>` and `NullableOf<T>` that allow you to use the LINQ syntax for using their inner values:

    Nullable<int> id = 5;
    NullableOf<string> category = "books";
    var result =
        from _category in category
        from _id in id
        select SearchItemInCategory(_category, _id);

If any of the values is null, the rest of the steps won't be computed, and only the null value is returned from the expression. This works similar to the null conditional operator (?.). This is also how monads work, if you're into that kind of thing.

## Known issues

* I couldn't name this type `Nullable<T>` despite how hard I tried. Of course, it's in its own namespace, but you always include `System`, so including my namespace would only cause a collision between `System.Nullable<T>` and `NullableClass.Nullable<T>`. Oh well.
* Properties and fields could use a smarter analysis to detect if they're assigned in the constructor. I'll need to study the Roslyn APIs more to be able to implement this.
* This will solve the null problem in your own code, but not on any external code. Unfortunately, since this is being written on top of the existing language, you'll still need to be careful interacting with it. If you know a method call can return null, immediately assign its value to a nullable variable.
* You can't use `null` in default parameter values, which means that, except for string's `""`, all default values will need to be nullable.
* If you find something I missed, or have an idea to contribute, please create a new issue.

## FAQ

* **Isn't the C# team already solving this issue in C# 8?**

Yes. Well, kinda. They want to keep backwards compatibility, which means they're only issuing warnings when the static analysis can detect incorrect null usage. This, unfortunately, completely misses the array case, and as far as I'm concerned, warnings = mere suggestions, despite what anyone would want. So, I'm creating this as an effort to introduce a true concept of nullable / non-nullable classes.

* **Aren't there any libraries that already do this?**

Yes, it's very easy to find `Maybe<T>` implementations. However, they focus too much on the functional programming value, and I wanted something that was closer to how `Nullable<T>` already works. If you like functional programming, maybe (hehe) my implementation won't be the best for you.

## License

[MIT](https://github.com/R2D221/NullableClass/blob/master/LICENSE), of course.
