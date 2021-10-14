export function BBox(element) {
    const bbox = element.getBBox();

    return { x: bbox.x, y: bbox.y, width: bbox.width, height: bbox.height }
}