import { toString, Record, Union } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { tuple_type, lambda_type, option_type, record_type, bool_type, class_type, list_type, string_type, int32_type, union_type } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { RollSpec$reflection } from "../Character.fs.js";
import { change, add, ofList, empty } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { singleton, cons, empty as empty_1 } from "../../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { FSharpResult$2 } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Choice.js";
import { notImpl, shouldntHappen, StateMonad_StateBuilder__Bind_3179, StateMonad_stateChange, StateMonad_StateBuilder__Return_1505, StateMonad_StateBuilder__Delay_Z38F4EA44, $007CLookup$007C_$007C } from "../Common.fs.js";
import { value as value_1 } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";
import { comparePrimitives, uncurry } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { empty as empty_2, ofList as ofList_1, filter, FSharpSet__Add, FSharpSet__Contains } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Set.js";

export class RuntimeType extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Number", "Id", "Text", "Roll", "Rolls", "Flags", "Bool"];
    }
}

export function RuntimeType$reflection() {
    return union_type("Domain.Ribbit.RuntimeType", [], RuntimeType, () => [[], [], [], [], [], [], []]);
}

export class RuntimeValue extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Number", "Id", "Text", "Roll", "Rolls", "Flags", "Bool"];
    }
}

export function RuntimeValue$reflection() {
    return union_type("Domain.Ribbit.RuntimeValue", [], RuntimeValue, () => [[["Item", int32_type]], [["Item", int32_type]], [["Item", string_type]], [["Item", RollSpec$reflection()]], [["Item", list_type(RollSpec$reflection())]], [["Item", class_type("Microsoft.FSharp.Collections.FSharpSet`1", [string_type])]], [["Item", bool_type]]]);
}

export class RibbitError extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DataRequest", "BugReport"];
    }
}

export function RibbitError$reflection() {
    return union_type("Domain.Ribbit.RibbitError", [], RibbitError, () => [[["Item1", int32_type], ["propertyName", string_type]], [["msg", string_type]]]);
}

export class Property {
    constructor(name, runtimeType) {
        this.name = name;
        this.runtimeType = runtimeType;
    }
}

export function Property$reflection() {
    return class_type("Domain.Ribbit.Property", void 0, Property);
}

export function Property_$ctor_Z79977D84(name, runtimeType) {
    return new Property(name, runtimeType);
}

export function Property__get_Name(this$) {
    return this$.name;
}

export function Property__get_Type(this$) {
    return this$.runtimeType;
}

export class Property$1 extends Property {
    constructor(name, runtimeType) {
        super(name, runtimeType);
    }
}

export function Property$1$reflection(gen0) {
    return class_type("Domain.Ribbit.Property`1", [gen0], Property$1, Property$reflection());
}

export function Property$1_$ctor_Z79977D84(name, runtimeType) {
    return new Property$1(name, runtimeType);
}

export class PropertiesByType extends Record {
    constructor(number, id, roll, rolls, flags, bool) {
        super();
        this.number = number;
        this.id = id;
        this.roll = roll;
        this.rolls = rolls;
        this.flags = flags;
        this.bool = bool;
    }
}

export function PropertiesByType$reflection() {
    return record_type("Domain.Ribbit.PropertiesByType", [], PropertiesByType, () => [["number", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, Property$1$reflection(int32_type)])], ["id", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, Property$1$reflection(int32_type)])], ["roll", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, Property$1$reflection(RollSpec$reflection())])], ["rolls", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, Property$1$reflection(list_type(RollSpec$reflection()))])], ["flags", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, Property$1$reflection(class_type("Microsoft.FSharp.Collections.FSharpSet`1", [string_type]))])], ["bool", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, Property$1$reflection(bool_type)])]]);
}

export class Scope extends Record {
    constructor(rows, biggestIdSoFar) {
        super();
        this.rows = rows;
        this.biggestIdSoFar = biggestIdSoFar;
    }
}

export function Scope$reflection() {
    return record_type("Domain.Ribbit.Scope", [], Scope, () => [["rows", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [int32_type, class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, RuntimeValue$reflection()])])], ["biggestIdSoFar", option_type(int32_type)]]);
}

export class Affordance extends Record {
    constructor(name, action) {
        super();
        this.name = name;
        this.action = action;
    }
}

export function Affordance$reflection() {
    return record_type("Domain.Ribbit.Affordance", [], Affordance, () => [["name", string_type], ["action", lambda_type(int32_type, lambda_type(State$reflection(), State$reflection()))]]);
}

export class State extends Record {
    constructor(properties, kindsOfMonsters, roster, categories, scope, affordances, openRequests) {
        super();
        this.properties = properties;
        this.kindsOfMonsters = kindsOfMonsters;
        this.roster = roster;
        this.categories = categories;
        this.scope = scope;
        this.affordances = affordances;
        this.openRequests = openRequests;
    }
}

export function State$reflection() {
    return record_type("Domain.Ribbit.State", [], State, () => [["properties", PropertiesByType$reflection()], ["kindsOfMonsters", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, int32_type])], ["roster", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, int32_type])], ["categories", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, list_type(tuple_type(int32_type, string_type))])], ["scope", Scope$reflection()], ["affordances", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, Affordance$reflection()])], ["openRequests", list_type(RibbitError$reflection())]]);
}

export function PropertiesByType_get_fresh() {
    return new PropertiesByType(empty(), empty(), empty(), empty(), empty(), empty());
}

export function Scope_get_fresh() {
    return new Scope(empty(), void 0);
}

export function State_get_fresh() {
    const scope = Scope_get_fresh();
    const kindsOfMonsters = empty();
    const roster = empty();
    const categories = empty();
    const affordances = empty();
    return new State(PropertiesByType_get_fresh(), kindsOfMonsters, roster, categories, scope, affordances, empty_1());
}

export class FightResult extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Victory", "Defeat", "Ongoing"];
    }
}

export function FightResult$reflection() {
    return union_type("Domain.Ribbit.FightResult", [], FightResult, () => [[], [], []]);
}

export class RoundResult extends Record {
    constructor(outcome, msgs, ribbit) {
        super();
        this.outcome = outcome;
        this.msgs = msgs;
        this.ribbit = ribbit;
    }
}

export function RoundResult$reflection() {
    return record_type("Domain.Ribbit.RoundResult", [], RoundResult, () => [["outcome", FightResult$reflection()], ["msgs", list_type(string_type)], ["ribbit", State$reflection()]]);
}

export class TreasureType extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
    }
}

export function TreasureType$reflection() {
    return union_type("Domain.Ribbit.TreasureType", [], TreasureType, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export function Ops_toStatement(logic, state) {
    return [void 0, logic(state)];
}

export function Ops_castFailure(runtimeType, id, propName, v) {
    return new FSharpResult$2(1, new RibbitError(1, `row #${id} property ${propName} was should be a ${runtimeType} but was actually ${v}`));
}

export function Ops_registerRequest(request, state) {
    return [void 0, new State(state.properties, state.kindsOfMonsters, state.roster, state.categories, state.scope, state.affordances, cons(request, state.openRequests))];
}

function Ops__get(rowId, propertyName, fallback, getter, state) {
    const recur = (rowId$0027_mut) => {
        let id;
        recur:
        while (true) {
            const rowId$0027 = rowId$0027_mut;
            const matchValue = state.scope.rows;
            let pattern_matching_result, value;
            const activePatternResult41955 = $007CLookup$007C_$007C(rowId$0027, matchValue);
            if (activePatternResult41955 != null) {
                const activePatternResult41957 = $007CLookup$007C_$007C(propertyName, activePatternResult41955);
                if (activePatternResult41957 != null) {
                    pattern_matching_result = 0;
                    value = activePatternResult41957;
                }
                else {
                    pattern_matching_result = 1;
                }
            }
            else {
                pattern_matching_result = 1;
            }
            switch (pattern_matching_result) {
                case 0: {
                    return getter(value);
                }
                case 1: {
                    let pattern_matching_result_1, id_1;
                    const activePatternResult41951 = $007CLookup$007C_$007C(rowId$0027, matchValue);
                    if (activePatternResult41951 != null) {
                        const activePatternResult41953 = $007CLookup$007C_$007C("prototype", activePatternResult41951);
                        if (activePatternResult41953 != null) {
                            if (activePatternResult41953.tag === 1) {
                                if ((id = (activePatternResult41953.fields[0] | 0), id > 0)) {
                                    pattern_matching_result_1 = 0;
                                    id_1 = activePatternResult41953.fields[0];
                                }
                                else {
                                    pattern_matching_result_1 = 1;
                                }
                            }
                            else {
                                pattern_matching_result_1 = 1;
                            }
                        }
                        else {
                            pattern_matching_result_1 = 1;
                        }
                    }
                    else {
                        pattern_matching_result_1 = 1;
                    }
                    switch (pattern_matching_result_1) {
                        case 0: {
                            rowId$0027_mut = id_1;
                            continue recur;
                        }
                        case 1: {
                            return fallback(rowId, propertyName, state);
                        }
                    }
                }
            }
            break;
        }
    };
    return recur(rowId);
}

export function Ops_getSynchronously(rowId, propertyName, defaultValue, getter) {
    const fallback = (_arg3, _arg2, _arg1) => {
        if (defaultValue == null) {
            return new FSharpResult$2(1, new RibbitError(1, `row #${rowId} property ${propertyName} was accessed synchronously but was actually missing`));
        }
        else {
            const v = value_1(defaultValue);
            return new FSharpResult$2(0, v);
        }
    };
    return (state) => Ops__get(rowId, propertyName, fallback, getter, state);
}

export function Ops_getAsync(rowId, propertyName, defaultValue, castRuntimeValue, state) {
    const fallback = (rowId_1) => ((propertyName_1) => StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => {
        if (defaultValue != null) {
            const v = value_1(defaultValue);
            return StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, new FSharpResult$2(0, v));
        }
        else {
            const req = new RibbitError(0, rowId_1, propertyName_1);
            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_1) => Ops_registerRequest(req, state_1), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, new FSharpResult$2(1, req))));
        }
    })));
    const getter = (runtimeValue) => [castRuntimeValue(runtimeValue), state];
    return Ops__get(rowId, propertyName, uncurry(3, fallback), getter, state);
}

export function Ops_setScope(rowId, propertyName, runtimeValue, scope) {
    const setProperty = (_arg1) => {
        if (_arg1 == null) {
            return ofList(singleton([propertyName, runtimeValue]));
        }
        else {
            const row = _arg1;
            return add(propertyName, runtimeValue, row);
        }
    };
    const data$0027 = change(rowId, setProperty, scope.rows);
    return new Scope(data$0027, scope.biggestIdSoFar);
}

export function Ops_upsertScope(rowId, propertyName, defaultValue, upsert, state) {
    const scope = state.scope;
    const setProperty = (_arg1) => {
        if (_arg1 == null) {
            const matchValue = Ops_getSynchronously(rowId, propertyName, defaultValue, (arg0_1) => (new FSharpResult$2(0, arg0_1)))(state);
            if (matchValue.tag === 1) {
                const err = matchValue.fields[0];
                return shouldntHappen();
            }
            else {
                const inheritedValue = matchValue.fields[0];
                return ofList(singleton([propertyName, upsert(inheritedValue)]));
            }
        }
        else {
            const row = _arg1;
            return change(propertyName, (arg) => upsert(arg), row);
        }
    };
    const data$0027 = change(rowId, setProperty, scope.rows);
    return new State(state.properties, state.kindsOfMonsters, state.roster, state.categories, new Scope(data$0027, scope.biggestIdSoFar), state.affordances, state.openRequests);
}

export function Ops_updateScope(state, f) {
    return new State(state.properties, state.kindsOfMonsters, state.roster, state.categories, f(state.scope), state.affordances, state.openRequests);
}

export function Ops_setState(args_0, args_1, args_2, state) {
    const args = [args_0, args_1, args_2];
    const args_3 = args;
    const runtimeValue = args_3[2];
    const rowId = args_3[0] | 0;
    const propertyName = args_3[1];
    return new State(state.properties, state.kindsOfMonsters, state.roster, state.categories, Ops_setScope(args_3[0], args_3[1], args_3[2], state.scope), state.affordances, state.openRequests);
}

export function Ops_hasValue(rowId, propertyName, state) {
    let pattern_matching_result;
    const activePatternResult41991 = $007CLookup$007C_$007C(rowId, state.scope.rows);
    if (activePatternResult41991 != null) {
        if ($007CLookup$007C_$007C(propertyName, activePatternResult41991) != null) {
            pattern_matching_result = 0;
        }
        else {
            pattern_matching_result = 1;
        }
    }
    else {
        pattern_matching_result = 1;
    }
    switch (pattern_matching_result) {
        case 0: {
            return true;
        }
        case 1: {
            return false;
        }
    }
}

export class NumberProperty extends Property$1 {
    constructor(name, defaultValue) {
        super(name, new RuntimeType(0));
        this.name_1 = name;
        this.defaultValue = defaultValue;
    }
    ["Domain.Ribbit.Property`1.Set"](rowId, value, state) {
        const this$ = this;
        return Ops_setState(rowId, this$.name_1, new RuntimeValue(0, value), state);
    }
    ["Domain.Ribbit.Property`1.SetM6570C449"](rowId, value) {
        const this$ = this;
        return (state_1) => Ops_toStatement((state) => Ops_setState(rowId, this$.name_1, new RuntimeValue(0, value), state), state_1);
    }
    ["Domain.Ribbit.Property`1.Get"](rowId, state) {
        const this$ = this;
        const matchValue = Ops_getSynchronously(rowId, this$.name_1, this$.defaultValue, (_arg1) => {
            if (_arg1.tag === 0) {
                const n = _arg1.fields[0] | 0;
                return new FSharpResult$2(0, n);
            }
            else {
                const v = _arg1;
                return Ops_castFailure(new RuntimeType(0), rowId, this$.name_1, v);
            }
        })(state);
        if (matchValue.tag === 1) {
            if (matchValue.fields[0].tag === 1) {
                const msg = matchValue.fields[0].fields[0];
                throw (new Error(msg));
            }
            else {
                return shouldntHappen() | 0;
            }
        }
        else {
            const value = matchValue.fields[0];
            return value | 0;
        }
    }
    ["Domain.Ribbit.Property`1.GetMZ524259A4"](rowId) {
        const this$ = this;
        return (state) => Ops_getAsync(rowId, this$.name_1, this$.defaultValue, (_arg2) => {
            if (_arg2.tag === 0) {
                const n = _arg2.fields[0] | 0;
                return new FSharpResult$2(0, n);
            }
            else {
                const v = _arg2;
                return Ops_castFailure(new RuntimeType(0), rowId, this$.name_1, v);
            }
        }, state);
    }
}

export function NumberProperty$reflection() {
    return class_type("Domain.Ribbit.NumberProperty", void 0, NumberProperty, Property$1$reflection(int32_type));
}

export function NumberProperty_$ctor_4E529C32(name, defaultValue) {
    return new NumberProperty(name, defaultValue);
}

export function NumberProperty_$ctor_Z18115A39(name, defaultValue) {
    return NumberProperty_$ctor_4E529C32(name, defaultValue);
}

export function NumberProperty_$ctor_Z721C83C5(name) {
    return NumberProperty_$ctor_4E529C32(name, void 0);
}

export class BoolProperty extends Property$1 {
    constructor(name, defaultValue) {
        super(name, new RuntimeType(6));
        this.name_1 = name;
        this.defaultValue = defaultValue;
    }
    ["Domain.Ribbit.Property`1.Set"](rowId, value, state) {
        const this$ = this;
        return Ops_setState(rowId, this$.name_1, new RuntimeValue(6, value), state);
    }
    ["Domain.Ribbit.Property`1.SetM6570C449"](rowId, value) {
        const this$ = this;
        return (state_1) => Ops_toStatement((state) => Ops_setState(rowId, this$.name_1, new RuntimeValue(6, value), state), state_1);
    }
    ["Domain.Ribbit.Property`1.Get"](rowId, state) {
        const this$ = this;
        const matchValue = Ops_getSynchronously(rowId, this$.name_1, this$.defaultValue, (_arg1) => {
            if (_arg1.tag === 6) {
                const b = _arg1.fields[0];
                return new FSharpResult$2(0, b);
            }
            else {
                const v = _arg1;
                return Ops_castFailure(new RuntimeType(0), rowId, this$.name_1, v);
            }
        })(state);
        if (matchValue.tag === 1) {
            if (matchValue.fields[0].tag === 1) {
                const msg = matchValue.fields[0].fields[0];
                throw (new Error(msg));
            }
            else {
                return shouldntHappen();
            }
        }
        else {
            const value = matchValue.fields[0];
            return value;
        }
    }
    ["Domain.Ribbit.Property`1.GetMZ524259A4"](rowId) {
        const this$ = this;
        return (state) => Ops_getAsync(rowId, this$.name_1, this$.defaultValue, (_arg2) => {
            if (_arg2.tag === 6) {
                const b = _arg2.fields[0];
                return new FSharpResult$2(0, b);
            }
            else {
                const v = _arg2;
                return Ops_castFailure(new RuntimeType(6), rowId, this$.name_1, v);
            }
        }, state);
    }
}

export function BoolProperty$reflection() {
    return class_type("Domain.Ribbit.BoolProperty", void 0, BoolProperty, Property$1$reflection(bool_type));
}

export function BoolProperty_$ctor_39B2A084(name, defaultValue) {
    return new BoolProperty(name, defaultValue);
}

export function BoolProperty_$ctor_Z55EFCE8F(name, defaultValue) {
    return BoolProperty_$ctor_39B2A084(name, defaultValue);
}

export function BoolProperty_$ctor_Z721C83C5(name) {
    return BoolProperty_$ctor_39B2A084(name, void 0);
}

export class RollProperty extends Property$1 {
    constructor(name, defaultValue) {
        super(name, new RuntimeType(3));
        this.name_1 = name;
        this.defaultValue = defaultValue;
    }
    ["Domain.Ribbit.Property`1.Set"](rowId, value, state) {
        const this$ = this;
        return Ops_setState(rowId, this$.name_1, new RuntimeValue(3, value), state);
    }
    ["Domain.Ribbit.Property`1.SetM6570C449"](rowId, value) {
        const this$ = this;
        return (state_1) => Ops_toStatement((state) => Ops_setState(rowId, this$.name_1, new RuntimeValue(3, value), state), state_1);
    }
    ["Domain.Ribbit.Property`1.Get"](rowId, state) {
        const this$ = this;
        const matchValue = Ops_getSynchronously(rowId, this$.name_1, this$.defaultValue, (_arg1) => {
            if (_arg1.tag === 3) {
                const r = _arg1.fields[0];
                return new FSharpResult$2(0, r);
            }
            else {
                const v = _arg1;
                return Ops_castFailure(new RuntimeType(0), rowId, this$.name_1, v);
            }
        })(state);
        if (matchValue.tag === 1) {
            if (matchValue.fields[0].tag === 1) {
                const msg = matchValue.fields[0].fields[0];
                throw (new Error(msg));
            }
            else {
                return shouldntHappen();
            }
        }
        else {
            const value = matchValue.fields[0];
            return value;
        }
    }
    ["Domain.Ribbit.Property`1.GetMZ524259A4"](rowId) {
        const this$ = this;
        return (state) => Ops_getAsync(rowId, this$.name_1, this$.defaultValue, (_arg2) => {
            if (_arg2.tag === 3) {
                const r = _arg2.fields[0];
                return new FSharpResult$2(0, r);
            }
            else {
                const v = _arg2;
                return Ops_castFailure(new RuntimeType(3), rowId, this$.name_1, v);
            }
        }, state);
    }
}

export function RollProperty$reflection() {
    return class_type("Domain.Ribbit.RollProperty", void 0, RollProperty, Property$1$reflection(RollSpec$reflection()));
}

export function RollProperty_$ctor_Z650BA636(name, defaultValue) {
    return new RollProperty(name, defaultValue);
}

export function RollProperty_$ctor_Z6433F2C1(name, defaultValue) {
    return RollProperty_$ctor_Z650BA636(name, defaultValue);
}

export function RollProperty_$ctor_Z721C83C5(name) {
    return RollProperty_$ctor_Z650BA636(name, void 0);
}

export class RollsProperty extends Property$1 {
    constructor(name, defaultValue) {
        super(name, new RuntimeType(4));
        this.name_1 = name;
        this.defaultValue = defaultValue;
    }
    ["Domain.Ribbit.Property`1.Set"](rowId, value, state) {
        const this$ = this;
        return Ops_setState(rowId, this$.name_1, new RuntimeValue(4, value), state);
    }
    ["Domain.Ribbit.Property`1.SetM6570C449"](rowId, value) {
        const this$ = this;
        return (state_1) => Ops_toStatement((state) => Ops_setState(rowId, this$.name_1, new RuntimeValue(4, value), state), state_1);
    }
    ["Domain.Ribbit.Property`1.Get"](rowId, state) {
        const this$ = this;
        const matchValue = Ops_getSynchronously(rowId, this$.name_1, this$.defaultValue, (_arg1) => {
            if (_arg1.tag === 4) {
                const rs = _arg1.fields[0];
                return new FSharpResult$2(0, rs);
            }
            else {
                const v = _arg1;
                return Ops_castFailure(new RuntimeType(0), rowId, this$.name_1, v);
            }
        })(state);
        if (matchValue.tag === 1) {
            if (matchValue.fields[0].tag === 1) {
                const msg = matchValue.fields[0].fields[0];
                throw (new Error(msg));
            }
            else {
                return shouldntHappen();
            }
        }
        else {
            const value = matchValue.fields[0];
            return value;
        }
    }
    ["Domain.Ribbit.Property`1.GetMZ524259A4"](rowId) {
        const this$ = this;
        return (state) => Ops_getAsync(rowId, this$.name_1, this$.defaultValue, (_arg2) => {
            if (_arg2.tag === 4) {
                const rs = _arg2.fields[0];
                return new FSharpResult$2(0, rs);
            }
            else {
                const v = _arg2;
                return Ops_castFailure(new RuntimeType(4), rowId, this$.name_1, v);
            }
        }, state);
    }
}

export function RollsProperty$reflection() {
    return class_type("Domain.Ribbit.RollsProperty", void 0, RollsProperty, Property$1$reflection(list_type(RollSpec$reflection())));
}

export function RollsProperty_$ctor_Z6BA01D60(name, defaultValue) {
    return new RollsProperty(name, defaultValue);
}

export function RollsProperty_$ctor_9E5A455(name, defaultValue) {
    return RollsProperty_$ctor_Z6BA01D60(name, defaultValue);
}

export function RollsProperty_$ctor_Z721C83C5(name) {
    return RollsProperty_$ctor_Z6BA01D60(name, void 0);
}

export class FlagsProperty$1 extends Property$1 {
    constructor(name, defaultValue) {
        super(name, new RuntimeType(5));
        this.name_1 = name;
        this.defaultValue = defaultValue;
    }
    ["Domain.Ribbit.Property`1.Set"](rowId, value, state) {
        const this$ = this;
        return Ops_setState(rowId, this$.name_1, new RuntimeValue(5, value), state);
    }
    ["Domain.Ribbit.Property`1.SetM6570C449"](rowId, value) {
        const this$ = this;
        return (state_1) => Ops_toStatement((state) => Ops_setState(rowId, this$.name_1, new RuntimeValue(5, value), state), state_1);
    }
    ["Domain.Ribbit.Property`1.Get"](rowId, state) {
        const this$ = this;
        const matchValue = Ops_getSynchronously(rowId, this$.name_1, this$.defaultValue, (_arg1) => {
            if (_arg1.tag === 5) {
                const f = _arg1.fields[0];
                return new FSharpResult$2(0, f);
            }
            else {
                return new FSharpResult$2(0, this$.defaultValue);
            }
        })(state);
        if (matchValue.tag === 1) {
            if (matchValue.fields[0].tag === 1) {
                const msg = matchValue.fields[0].fields[0];
                throw (new Error(msg));
            }
            else {
                return shouldntHappen();
            }
        }
        else {
            const value = matchValue.fields[0];
            return value;
        }
    }
    ["Domain.Ribbit.Property`1.GetMZ524259A4"](rowId) {
        const this$ = this;
        return (state) => Ops_getAsync(rowId, this$.name_1, this$.defaultValue, (_arg2) => {
            if (_arg2.tag === 5) {
                const b = _arg2.fields[0];
                return new FSharpResult$2(0, b);
            }
            else {
                const v = _arg2;
                return Ops_castFailure(new RuntimeType(5), rowId, this$.name_1, v);
            }
        }, state);
    }
}

export function FlagsProperty$1$reflection(gen0) {
    return class_type("Domain.Ribbit.FlagsProperty`1", [gen0], FlagsProperty$1, Property$1$reflection(class_type("Microsoft.FSharp.Collections.FSharpSet`1", [string_type])));
}

export function FlagsProperty$1_$ctor_659810CA(name, defaultValue) {
    return new FlagsProperty$1(name, defaultValue);
}

export function FlagsProperty$1__SetAll_4AB9628D(this$, rowId, value) {
    const tupledArg = [rowId, value];
    return (arg10) => this$["Domain.Ribbit.Property`1.Set"](tupledArg[0], tupledArg[1], arg10);
}

export function FlagsProperty$1__SetFlag(this$, rowId, targetFlag, value, state) {
    let target;
    let copyOfStruct = targetFlag;
    target = toString(copyOfStruct);
    return Ops_upsertScope(rowId, this$.name_1, new RuntimeValue(5, this$.defaultValue), (_arg3) => {
        let pattern_matching_result, set$;
        if (_arg3 != null) {
            if (_arg3.tag === 5) {
                pattern_matching_result = 0;
                set$ = _arg3.fields[0];
            }
            else {
                pattern_matching_result = 1;
            }
        }
        else {
            pattern_matching_result = 1;
        }
        switch (pattern_matching_result) {
            case 0: {
                if (value === FSharpSet__Contains(set$, target)) {
                    return new RuntimeValue(5, set$);
                }
                else if (value) {
                    return new RuntimeValue(5, FSharpSet__Add(set$, target));
                }
                else {
                    return new RuntimeValue(5, filter((y) => (target !== y), set$));
                }
            }
            case 1: {
                return new RuntimeValue(5, ofList_1(value ? singleton(target) : empty_1(), {
                    Compare: (x, y_1) => comparePrimitives(x, y_1),
                }));
            }
        }
    }, state);
}

export function FlagsProperty$1__SetAllM(this$, rowId, value, state) {
    return [void 0, FlagsProperty$1__SetAll_4AB9628D(this$, rowId, value)(state)];
}

export function FlagsProperty$1__SetFlagM(this$, rowId, targetFlag, value, state) {
    let tupledArg;
    return [void 0, (tupledArg = [rowId, targetFlag, value], FlagsProperty$1__SetFlag(this$, tupledArg[0], tupledArg[1], tupledArg[2], state))];
}

export function FlagsProperty$1__Check(this$, rowId, targetFlag, state) {
    let target;
    let copyOfStruct = targetFlag;
    target = toString(copyOfStruct);
    const check = (set$) => FSharpSet__Contains(set$, target);
    const matchValue = Ops_getSynchronously(rowId, this$.name_1, false, (_arg4) => {
        if (_arg4.tag === 5) {
            const flags = _arg4.fields[0];
            return new FSharpResult$2(0, check(flags));
        }
        else {
            const v = _arg4;
            return Ops_castFailure(new RuntimeType(5), rowId, this$.name_1, v);
        }
    })(state);
    if (matchValue.tag === 1) {
        const err = matchValue.fields[0];
        return shouldntHappen(err);
    }
    else {
        const v_1 = matchValue.fields[0];
        return v_1;
    }
}

export function FlagsProperty$1__CheckM(this$, rowId, targetFlag, state) {
    let target;
    let copyOfStruct = targetFlag;
    target = toString(copyOfStruct);
    const check = (set$) => FSharpSet__Contains(set$, target);
    return Ops_getAsync(rowId, this$.name_1, false, (_arg5) => {
        if (_arg5.tag === 5) {
            const flags = _arg5.fields[0];
            return new FSharpResult$2(0, check(flags));
        }
        else {
            const v = _arg5;
            return Ops_castFailure(new RuntimeType(5), rowId, this$.name_1, v);
        }
    }, state);
}

export function FlagsProperty$1_$ctor_Z721C83C5(name) {
    return FlagsProperty$1_$ctor_659810CA(name, empty_2({
        Compare: (x, y) => comparePrimitives(x, y),
    }));
}

export class IdProperty extends Property$1 {
    constructor(name, defaultValue) {
        super(name, new RuntimeType(1));
        this.name_1 = name;
        this.defaultValue = defaultValue;
    }
    ["Domain.Ribbit.Property`1.Set"](rowId, value, state) {
        const this$ = this;
        return Ops_setState(rowId, this$.name_1, new RuntimeValue(1, value), state);
    }
    ["Domain.Ribbit.Property`1.SetM6570C449"](rowId, value) {
        const this$ = this;
        return (state_1) => Ops_toStatement((state) => Ops_setState(rowId, this$.name_1, new RuntimeValue(1, value), state), state_1);
    }
    ["Domain.Ribbit.Property`1.Get"](rowId, state) {
        const this$ = this;
        const matchValue = Ops_getSynchronously(rowId, this$.name_1, this$.defaultValue, (_arg1) => {
            if (_arg1.tag === 1) {
                const id = _arg1.fields[0] | 0;
                return new FSharpResult$2(0, id);
            }
            else {
                const v = _arg1;
                return Ops_castFailure(new RuntimeType(0), rowId, this$.name_1, v);
            }
        })(state);
        if (matchValue.tag === 1) {
            if (matchValue.fields[0].tag === 1) {
                const msg = matchValue.fields[0].fields[0];
                throw (new Error(msg));
            }
            else {
                return shouldntHappen() | 0;
            }
        }
        else {
            const value = matchValue.fields[0];
            return value | 0;
        }
    }
    ["Domain.Ribbit.Property`1.GetMZ524259A4"](rowId) {
        const this$ = this;
        return (state) => Ops_getAsync(rowId, this$.name_1, this$.defaultValue, (_arg2) => {
            if (_arg2.tag === 1) {
                const id = _arg2.fields[0] | 0;
                return new FSharpResult$2(0, id);
            }
            else {
                const v = _arg2;
                return Ops_castFailure(new RuntimeType(1), rowId, this$.name_1, v);
            }
        }, state);
    }
}

export function IdProperty$reflection() {
    return class_type("Domain.Ribbit.IdProperty", void 0, IdProperty, Property$1$reflection(int32_type));
}

export function IdProperty_$ctor_4E529C32(name, defaultValue) {
    return new IdProperty(name, defaultValue);
}

export function IdProperty_$ctor_Z18115A39(name, defaultValue) {
    return IdProperty_$ctor_4E529C32(name, defaultValue);
}

export function IdProperty_$ctor_Z721C83C5(name) {
    return IdProperty_$ctor_4E529C32(name, void 0);
}

export class TextProperty extends Property$1 {
    constructor(name, defaultValue) {
        super(name, new RuntimeType(2));
        this.name_1 = name;
        this.defaultValue = defaultValue;
    }
    ["Domain.Ribbit.Property`1.Set"](rowId, value, state) {
        const this$ = this;
        return Ops_setState(rowId, this$.name_1, new RuntimeValue(2, value), state);
    }
    ["Domain.Ribbit.Property`1.SetM6570C449"](rowId, value) {
        const this$ = this;
        return (state_1) => Ops_toStatement((state) => Ops_setState(rowId, this$.name_1, new RuntimeValue(2, value), state), state_1);
    }
    ["Domain.Ribbit.Property`1.Get"](rowId, state) {
        const this$ = this;
        const matchValue = Ops_getSynchronously(rowId, this$.name_1, this$.defaultValue, (_arg1) => {
            if (_arg1.tag === 2) {
                const t = _arg1.fields[0];
                return new FSharpResult$2(0, t);
            }
            else {
                const v = _arg1;
                return Ops_castFailure(new RuntimeType(0), rowId, this$.name_1, v);
            }
        })(state);
        if (matchValue.tag === 1) {
            if (matchValue.fields[0].tag === 1) {
                const msg = matchValue.fields[0].fields[0];
                throw (new Error(msg));
            }
            else {
                return shouldntHappen();
            }
        }
        else {
            const value = matchValue.fields[0];
            return value;
        }
    }
    ["Domain.Ribbit.Property`1.GetMZ524259A4"](rowId) {
        const this$ = this;
        return (state) => Ops_getAsync(rowId, this$.name_1, this$.defaultValue, (_arg2) => {
            if (_arg2.tag === 2) {
                const t = _arg2.fields[0];
                return new FSharpResult$2(0, t);
            }
            else {
                const v = _arg2;
                return Ops_castFailure(new RuntimeType(2), rowId, this$.name_1, v);
            }
        }, state);
    }
}

export function TextProperty$reflection() {
    return class_type("Domain.Ribbit.TextProperty", void 0, TextProperty, Property$1$reflection(string_type));
}

export function TextProperty_$ctor_68C4AEB5(name, defaultValue) {
    return new TextProperty(name, defaultValue);
}

export function TextProperty_$ctor_Z384F8060(name, defaultValue) {
    return TextProperty_$ctor_68C4AEB5(name, defaultValue);
}

export function TextProperty_$ctor_Z721C83C5(name) {
    return TextProperty_$ctor_68C4AEB5(name, void 0);
}

export class MessagesProofOfConcept_Binary {
    constructor(lhs, rhs, f) {
        this.lhs = lhs;
        this.rhs = rhs;
        this.f = f;
    }
}

export function MessagesProofOfConcept_Binary$reflection() {
    return class_type("Domain.Ribbit.MessagesProofOfConcept.Binary", void 0, MessagesProofOfConcept_Binary);
}

export function MessagesProofOfConcept_Binary_$ctor_ZDE1267E(lhs, rhs, f) {
    return new MessagesProofOfConcept_Binary(lhs, rhs, f);
}

export function MessagesProofOfConcept_Binary__Result_3E0FA0D4(this$, state) {
    return this$.f([this$.lhs(state), this$.rhs(state)]);
}

export class MessagesProofOfConcept_Expression extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Deref", "Transform2"];
    }
}

export function MessagesProofOfConcept_Expression$reflection() {
    return union_type("Domain.Ribbit.MessagesProofOfConcept.Expression", [], MessagesProofOfConcept_Expression, () => [[["Item1", int32_type], ["Item2", Property$reflection()]], [["Item", MessagesProofOfConcept_Binary$reflection()]]]);
}

export function MessagesProofOfConcept_deref(id, prop) {
    return notImpl();
}

export function MessagesProofOfConcept_binaryOp(lhs, rhs, combine, state) {
    const patternInput = lhs(state);
    const state_1 = patternInput[1];
    const lhs_1 = patternInput[0];
    const patternInput_1 = rhs(state_1);
    const state_2 = patternInput_1[1];
    const rhs_1 = patternInput_1[0];
    const patternInput_2 = combine(lhs_1, rhs_1, state_2);
    const state_3 = patternInput_2[1];
    const output = patternInput_2[0];
    return [output, state_3];
}

//# sourceMappingURL=Types.fs.js.map
