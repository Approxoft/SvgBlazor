window.highlightCodeElement = (element) => {
    if (element && element.children.length > 0) {
        var firstChild = element.firstElementChild;

        if (firstChild.children.length > 0) {
            var firstGrandchild = firstChild.firstElementChild;
            hljs.highlightElement(firstGrandchild);
        } else {
            hljs.highlightElement(firstChild);
        }
    }
};

window.highlightAllCode = () => {
    hljs.highlightAll();
};