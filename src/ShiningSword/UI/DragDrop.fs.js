import { class_type } from "../fable_modules/fable-library.3.6.2/Reflection.js";
import { Interop_reactApi } from "../fable_modules/Feliz.1.61.0/Interop.fs.js";
import { DropTarget, DragDropContainer } from "react-drag-drop-container";
import { createObj } from "../fable_modules/fable-library.3.6.2/Util.js";

export class Prop {
    constructor() {
    }
}

export function Prop$reflection() {
    return class_type("UI.DragDrop.Prop", void 0, Prop);
}

export function Prop_$ctor() {
    return new Prop();
}

export const prop = Prop_$ctor();

export function container(props) {
    return Interop_reactApi.createElement(DragDropContainer, createObj(props));
}

export function target(props) {
    return Interop_reactApi.createElement(DropTarget, createObj(props));
}

//# sourceMappingURL=DragDrop.fs.js.map
