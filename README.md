# About
SvgBlazor is a simple library that allows you to write C# code that is transformed directly into svg elements. Thanks to its simple, yet powerful API, you can easily compose beautiful svg drawings.

# Getting started
## 1. Package installation

To install SvgBlazor use NuGet Package Manager or install it with the following command:
```
dotnet add package SvgBlazor
```

## 2. Imports
Once the installation is complete, add SvgBlazor in _Imports.razor:
```
@using SvgBlazor
```

## 3. Create a SVG component
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

## 4. Enjoy the library!

# MIT License
Copyright 2021 <COPYRIGHT HOLDER>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
