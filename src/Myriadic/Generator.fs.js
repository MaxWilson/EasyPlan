import { Attribute } from "../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { name, class_type } from "../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";

export class LensAttribute extends Attribute {
    constructor(wrapperName) {
        super();
        this._wrapperName = wrapperName;
    }
}

export function LensAttribute$reflection() {
    return class_type("Myriadic.Generator.LensAttribute", void 0, LensAttribute, class_type("System.Attribute"));
}

export function LensAttribute_$ctor_Z721C83C5(wrapperName) {
    return new LensAttribute(wrapperName);
}

export function LensAttribute__get_WrapperName(this$) {
    return this$._wrapperName;
}

export function LensAttribute_$ctor() {
    return LensAttribute_$ctor_Z721C83C5(null);
}

export function LensAttribute_$ctor_24524716(type) {
    return LensAttribute_$ctor_Z721C83C5(name(type));
}

export class DuCasesAttribute extends Attribute {
    constructor(wrapperName) {
        super();
        this._wrapperName = wrapperName;
    }
}

export function DuCasesAttribute$reflection() {
    return class_type("Myriadic.Generator.DuCasesAttribute", void 0, DuCasesAttribute, class_type("System.Attribute"));
}

export function DuCasesAttribute_$ctor_Z721C83C5(wrapperName) {
    return new DuCasesAttribute(wrapperName);
}

export function DuCasesAttribute__get_WrapperName(this$) {
    return this$._wrapperName;
}

export function DuCasesAttribute_$ctor() {
    return DuCasesAttribute_$ctor_Z721C83C5(null);
}

export function DuCasesAttribute_$ctor_24524716(type) {
    return DuCasesAttribute_$ctor_Z721C83C5(name(type));
}

//# sourceMappingURL=Generator.fs.js.map
