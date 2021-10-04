using System.Drawing;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class SvgDraggableTest : TestContext
    {
        [Fact]
        public void MoveSvgElement()
        {
            var comp = RenderComponent<SvgComponent>();
            var groupDraggable = new SvgDraggable();
            var elementToMove = new DummyElement();
            groupDraggable.Add(elementToMove);
            comp.InvokeAsync(() => comp.Instance.Add(groupDraggable));
            comp.Render();

            var elementToMoveRendered = comp.Find(elementToMove.Tag());
            elementToMoveRendered.MouseOver(new MouseEventArgs());

            var groupDraggableRendered = comp.Find(groupDraggable.Tag());
            groupDraggableRendered.MouseDown(new MouseEventArgs());
            groupDraggableRendered.MouseMove(new MouseEventArgs{ OffsetX = 100, OffsetY = 200 });
            groupDraggableRendered.MouseUp(new MouseEventArgs());

            Assert.Equal("100", elementToMoveRendered.GetAttribute("x"));
            Assert.Equal("200", elementToMoveRendered.GetAttribute("y"));
        }

        private class DummyElement : SvgElement
        {
            public override string Tag() => "dummy";
            public override RectangleF BoundingRect() => new RectangleF();

            public override void AddAttributes(RenderTreeBuilder builder)
            {
                base.AddAttributes(builder);
                builder.AddAttribute(0, "x", X);
                builder.AddAttribute(1, "y", Y);
            }
        }
    }
}