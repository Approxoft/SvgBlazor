window.highlightCodeElement = (element) => {
    if (element && element.children.length > 0) {
        var firstChild = element.children[0];

        if (firstChild.children.length > 0) {
            var firstGrandchild = firstChild.children[0];
            hljs.highlightElement(firstGrandchild);
        } else {
            hljs.highlightElement(firstChild);
        }
    }
};

window.highlightAllCode = () => {
    hljs.highlightAll();
};