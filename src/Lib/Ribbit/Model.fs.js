import { Record } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { record_type, class_type, int32_type, string_type } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { empty } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";

export class Scope extends Record {
    constructor(hp, damage) {
        super();
        this.hp = hp;
        this.damage = damage;
    }
}

export function Scope$reflection() {
    return record_type("Domain.Ribbit.Types.Scope", [], Scope, () => [["hp", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, int32_type])], ["damage", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, int32_type])]]);
}

export function Scope_get_fresh() {
    return new Scope(empty(), empty());
}

export class State extends Record {
    constructor(rows) {
        super();
        this.rows = rows;
    }
}

export function State$reflection() {
    return record_type("Domain.Ribbit.Types.State", [], State, () => [["rows", Scope$reflection()]]);
}

export function State_get_fresh() {
    return new State(Scope_get_fresh());
}

