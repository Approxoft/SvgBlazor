SvgBlazor
=========

## About
SvgBlazor is a simple library that allows you to write C# code that is transformed directly into svg elements. Thanks to its simple, yet powerful API, you can easily compose beautiful svg drawings.

## Getting started
### 1. Package installation

To install SvgBlazor use NuGet Package Manager or install it with the following command:
```
dotnet add package SvgBlazor
```

### 2. Imports
Once the installation is complete, add SvgBlazor in _Imports.razor:
```
@using SvgBlazor
```

### 3. Create a SVG component
Add a SvgComponent tag in your .razor file and capture it's reference by using @ref property:

```
<SvgComponent Width="200" Height="200" @ref="svgComponent" />

@code {
    private SvgComponent svgComponent;

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            var circle = new SvgCircle
            {
                CenterX = 100,
                CenterY = 100,
                Radius = 100,
                Fill = new SvgFill
                {
                    Color = "#FF2800",
                },
            };

            svgComponent.Add(circle);
        }
    }
}
```

### 4. Enjoy the library!

## License
This software is released under the MIT license.
