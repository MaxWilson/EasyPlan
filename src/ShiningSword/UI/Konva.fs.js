import { Interop_reactApi } from "../fable_modules/Feliz.1.61.0/Interop.fs.js";
import { Text as Text$_1, Rect as Rect_1, Circle as Circle_1, Layer as Layer_1, Stage as Stage_1 } from "react-konva";
import { createObj } from "../fable_modules/fable-library.3.6.2/Util.js";
import { class_type } from "../fable_modules/fable-library.3.6.2/Reflection.js";

export function stage(props) {
    return Interop_reactApi.createElement(Stage_1, createObj(props));
}

export function layer(props) {
    return Interop_reactApi.createElement(Layer_1, createObj(props));
}

export function circle(props) {
    return Interop_reactApi.createElement(Circle_1, createObj(props));
}

export function rect(props) {
    return Interop_reactApi.createElement(Rect_1, createObj(props));
}

export function text(props) {
    return Interop_reactApi.createElement(Text$_1, createObj(props));
}

export class Shape {
    constructor() {
    }
}

export function Shape$reflection() {
    return class_type("UI.Konva.Shape", void 0, Shape);
}

export function Shape_get_draggable() {
    return ["draggable", true];
}

export class Circle {
    constructor() {
    }
}

export function Circle$reflection() {
    return class_type("UI.Konva.Circle", void 0, Circle, Shape$reflection());
}

export class Rect {
    constructor() {
    }
}

export function Rect$reflection() {
    return class_type("UI.Konva.Rect", void 0, Rect, Shape$reflection());
}

export class Stage {
    constructor() {
    }
}

export function Stage$reflection() {
    return class_type("UI.Konva.Stage", void 0, Stage, Shape$reflection());
}

export class Layer {
    constructor() {
    }
}

export function Layer$reflection() {
    return class_type("UI.Konva.Layer", void 0, Layer, Shape$reflection());
}

export class Text$ {
    constructor() {
    }
}

export function Text$$reflection() {
    return class_type("UI.Konva.Text", void 0, Text$, Shape$reflection());
}

//# sourceMappingURL=Konva.fs.js.map
