import { curry, uncurry, max, min, compare, equals, randomNext } from "../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { split, compare as compare_1, join, printf, toText } from "../ShiningSword/fable_modules/fable-library.3.6.2/String.js";
import { FSharpRef, Record, Union, FSharpException } from "../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { record_type, tuple_type, list_type, lambda_type, unit_type, union_type, int32_type, class_type } from "../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { reduce, map as map_2, length, skip, head as head_1 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Seq.js";
import { foldBack, append, exists, empty, singleton, cons, ofArray, collect, reverse, tail as tail_1, head as head_2, isEmpty } from "../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { iterateIndexed, map as map_1 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Array.js";
import { empty as empty_1, tryFind, add } from "../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { defaultArg, value as value_2, ofNullable } from "../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";
import { FSharpResult$2 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Choice.js";
import { Operations_over_Z4EEE036B } from "./Optics.fs.js";

export function flip(f, x, y) {
    return f(y, x);
}

export const random = {};

export function rand(x) {
    return 1 + randomNext(0, x);
}

export function thunk(v, _arg1) {
    return v;
}

export function thunk1(f, arg, _arg1) {
    return f(arg);
}

export function thunk2(f, arg1, arg2, _arg1) {
    return f(arg1, arg2);
}

export function thunk3(f, arg1, arg2, arg3, _arg1) {
    return f(arg1, arg2, arg3);
}

export function ignore1(f, _arg1) {
    return f();
}

export function tuple2(x, y) {
    return [x, y];
}

export function matchfail(v) {
    const message = toText(printf("No match found for %A. This is a bug."))(v);
    throw (new Error(message));
}

export class BugException extends FSharpException {
    constructor(msg) {
        super();
        this.msg = msg;
    }
}

export function BugException$reflection() {
    return class_type("Common.BugException", void 0, BugException, class_type("System.Exception"));
}

function BugException__Equals_229D3F39(this$, obj) {
    if (!equals(this$, null)) {
        if (!equals(obj, null)) {
            if (obj instanceof BugException) {
                return this$.msg === obj.msg;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }
    else if (!equals(obj, null)) {
        return false;
    }
    else {
        return true;
    }
}

export function notImpl(_arg1) {
    throw (new Error("Not implemented yet. Email Max if you want this feature."));
}

export function shouldntHappen(arg) {
    const exn = new BugException(`This shouldn't ever happen. If it does there's a bug. Details: ${arg}`);
    throw exn;
}

export const emptyString = "";

export function betweenInclusive(a, b, n) {
    if (compare(min((x, y) => compare(x, y), a, b), n) <= 0) {
        return compare(n, max((x_1, y_1) => compare(x_1, y_1), a, b)) <= 0;
    }
    else {
        return false;
    }
}

export function inv(f) {
    return f();
}

export function chooseRandom(options) {
    return head_1(skip(randomNext(0, length(options)), options));
}

export function chooseRandomExponentialDecay(acceptRate, options) {
    const recur = (_arg1_mut) => {
        recur:
        while (true) {
            const _arg1 = _arg1_mut;
            if (isEmpty(_arg1)) {
                return head_2(options);
            }
            else {
                const rest = tail_1(_arg1);
                const option = head_2(_arg1);
                if (Math.random() < acceptRate) {
                    return option;
                }
                else {
                    _arg1_mut = rest;
                    continue recur;
                }
            }
            break;
        }
    };
    return recur(options);
}

export function iter(data, f) {
    data.contents = f(data.contents);
    return data.contents;
}

export function iteri(data, f) {
    data.contents = f(data.contents);
}

export function shuffleCopy() {
    const swap = (a, x, y) => {
        const tmp = a[x];
        a[x] = a[y];
        a[y] = tmp;
    };
    return (a_1) => {
        const a_2 = map_1((x_1) => x_1, a_1);
        iterateIndexed((i, _arg1) => {
            swap(a_2, i, randomNext(i, a_2.length));
        }, a_2);
        return a_2;
    };
}

export class Ops {
    constructor() {
    }
}

export function Ops$reflection() {
    return class_type("Common.Ops", void 0, Ops);
}

export function Ops_add_1F6216BE(key, value, data) {
    return add(key, value, data);
}

export function Ops_addTo_2FBA9827(data) {
    return (key) => ((value) => Ops_add_1F6216BE(key, value, data));
}

export function String_oxfordJoin(_arg1) {
    if (isEmpty(_arg1)) {
        return emptyString;
    }
    else if (isEmpty(tail_1(_arg1))) {
        const a_1 = head_2(_arg1);
        return a_1;
    }
    else if (isEmpty(tail_1(tail_1(_arg1)))) {
        const a = head_2(_arg1);
        const b = head_2(tail_1(_arg1));
        return toText(printf("%s and %s"))(a)(b);
    }
    else {
        const _rest = tail_1(tail_1(tail_1(_arg1)));
        const lst = _arg1;
        const matchValue = reverse(lst);
        if (!isEmpty(matchValue)) {
            const rest = tail_1(matchValue);
            const last = head_2(matchValue);
            const arg10 = join(", ", reverse(rest));
            return toText(printf("%s, and %s"))(arg10)(last);
        }
        else {
            return shouldntHappen();
        }
    }
}

export function String_join(delimiter, strings) {
    return join(delimiter, strings);
}

export function String_equalsIgnoreCase(lhs, rhs) {
    return compare_1(lhs, rhs, 3) === 0;
}

export function String_firstWord(input) {
    const matchValue = ofNullable(input);
    if (matchValue == null) {
        return input;
    }
    else {
        const v = matchValue;
        return head_1(split(v.trim(), [" "], null, 0));
    }
}

export function String_trim(s) {
    return s.trim();
}

export function List_join(delimiter, lst) {
    let pattern_matching_result, head, tail;
    if (!isEmpty(lst)) {
        if (isEmpty(tail_1(lst))) {
            pattern_matching_result = 0;
        }
        else {
            pattern_matching_result = 1;
            head = head_2(lst);
            tail = tail_1(lst);
        }
    }
    else {
        pattern_matching_result = 0;
    }
    switch (pattern_matching_result) {
        case 0: {
            return lst;
        }
        case 1: {
            return cons(head, collect((x) => ofArray([delimiter, x]), tail));
        }
    }
}

export function List_ofOption(_arg1) {
    if (_arg1 != null) {
        const v = value_2(_arg1);
        return singleton(v);
    }
    else {
        return empty();
    }
}

export function List_every(f) {
    return (arg_1) => (!exists((arg) => (!f(arg)), arg_1));
}

export function List_tryMapFold(f_mut, state_mut, lst_mut) {
    List_tryMapFold:
    while (true) {
        const f = f_mut, state = state_mut, lst = lst_mut;
        if (!isEmpty(lst)) {
            const t = tail_1(lst);
            const h = head_2(lst);
            const matchValue = f(state, h);
            if (matchValue.tag === 0) {
                const state$0027 = matchValue.fields[0];
                f_mut = f;
                state_mut = state$0027;
                lst_mut = t;
                continue List_tryMapFold;
            }
            else {
                const e = matchValue;
                return e;
            }
        }
        else {
            return new FSharpResult$2(0, state);
        }
        break;
    }
}

export function Map_keys(m) {
    return map_2((_arg1) => {
        const k = _arg1[0];
        return k;
    }, m);
}

export function Map_values(m) {
    return map_2((_arg1) => {
        const v = _arg1[1];
        return v;
    }, m);
}

export function Map_addForce(key, f, m) {
    const matchValue = tryFind(key, m);
    if (matchValue == null) {
        return add(key, f(empty_1()), m);
    }
    else {
        const v = matchValue;
        const v$0027 = f(v);
        if (v.Equals(v$0027)) {
            return m;
        }
        else {
            return add(key, v$0027, m);
        }
    }
}

export function Map_findForce(key, m) {
    return defaultArg(tryFind(key, m), empty_1());
}

export class IdGenerator extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["NextId"];
    }
}

export function IdGenerator$reflection() {
    return union_type("Common.IdGenerator", [], IdGenerator, () => [[["Item", int32_type]]]);
}

export function IdGenerator_get_fresh() {
    return new IdGenerator(0, 1);
}

export function IdGenerator_newId(idGenerator_, model) {
    let id$0027 = 0;
    const model$0027 = Operations_over_Z4EEE036B(idGenerator_)((_arg1) => {
        const id = _arg1.fields[0] | 0;
        id$0027 = (id | 0);
        return new IdGenerator(0, id$0027 + 1);
    })(model);
    return [id$0027, model$0027];
}

export function Queue_append(item, queue) {
    return append(queue, singleton(item));
}

export function Queue_empty() {
    return empty();
}

export function Queue_read(queue) {
    return queue;
}

export function Ops_add_Z43558E54(item, data) {
    return Queue_append(item, data);
}

export function Ops_addTo_Z43573BF7(data) {
    return (item) => Ops_add_Z43558E54(item, data);
}

class Stateful_Seed$2 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Seed"];
    }
}

function Stateful_Seed$2$reflection(gen0, gen1) {
    return union_type("Common.Stateful.Seed`2", [gen0, gen1], Stateful_Seed$2, () => [[["initial", lambda_type(unit_type, gen0)], ["update", lambda_type(gen1, lambda_type(gen0, gen0))]]]);
}

export class Stateful_State$2 extends Record {
    constructor(seed, shared, past, queue) {
        super();
        this.seed = seed;
        this.shared = shared;
        this.past = past;
        this.queue = queue;
    }
}

export function Stateful_State$2$reflection(gen0, gen1) {
    return record_type("Common.Stateful.State`2", [gen0, gen1], Stateful_State$2, () => [["seed", Stateful_Seed$2$reflection(gen0, gen1)], ["shared", record_type("Microsoft.FSharp.Core.FSharpRef`1", [tuple_type(gen0, list_type(gen1))], FSharpRef, () => [["contents", tuple_type(gen0, list_type(gen1))]])], ["past", list_type(gen1)], ["queue", list_type(gen1)]]);
}

export function Stateful_State$2_create_1F85672B(initial, update) {
    const shared = new FSharpRef([initial(), empty()]);
    return new Stateful_State$2(new Stateful_Seed$2(0, initial, update), shared, empty(), empty());
}

export function Stateful_$007CDeref$007C(cell) {
    return cell.contents;
}

export function Stateful_deref(_arg1) {
    let this$, sharedPast, past, current;
    let pattern_matching_result, current_1, past_1, sharedPast_1, this$_1;
    const activePatternResult12719 = Stateful_$007CDeref$007C(_arg1.shared);
    if (isEmpty(_arg1.queue)) {
        if ((this$ = _arg1, (sharedPast = activePatternResult12719[1], (past = _arg1.past, (current = activePatternResult12719[0], equals(sharedPast, past)))))) {
            pattern_matching_result = 0;
            current_1 = activePatternResult12719[0];
            past_1 = _arg1.past;
            sharedPast_1 = activePatternResult12719[1];
            this$_1 = _arg1;
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
            return [current_1, this$_1];
        }
        case 1: {
            const activePatternResult12718 = Stateful_$007CDeref$007C(_arg1.shared);
            const update = _arg1.seed.fields[1];
            const this$_2 = _arg1;
            const sharedPast_2 = activePatternResult12718[1];
            const shared = _arg1.shared;
            const queue = _arg1.queue;
            const past_2 = _arg1.past;
            const init = _arg1.seed.fields[0];
            const current_2 = activePatternResult12718[0];
            const apply = (q, state) => foldBack(update, q, state);
            let patternInput;
            if (equals(sharedPast_2, past_2)) {
                patternInput = [apply(queue, current_2), append(queue, past_2)];
            }
            else {
                const combined = append(queue, past_2);
                patternInput = [apply(combined, init()), combined];
            }
            const past$0027 = patternInput[1];
            const current$0027 = patternInput[0];
            shared.contents = [current$0027, past$0027];
            return [current$0027, new Stateful_State$2(this$_2.seed, shared, past$0027, empty())];
        }
    }
}

export function Stateful_execute(msg, _arg1) {
    const this$ = _arg1;
    const queue = this$.queue;
    return new Stateful_State$2(this$.seed, this$.shared, this$.past, cons(msg, queue));
}

export function StateMonad_getState(s) {
    return [s, s];
}

export function StateMonad_putState(s, _arg1) {
    return [void 0, s];
}

export function StateMonad_eval(m, s) {
    return m(s)[0];
}

export function StateMonad_exec(m, s) {
    return m(s)[1];
}

export function StateMonad_empty(s) {
    return [void 0, s];
}

export function StateMonad_bind(k, m, s) {
    const patternInput = m(s);
    const s$0027 = patternInput[1];
    const a = patternInput[0];
    return k(a, s$0027);
}

function StateMonad_State_get(s) {
    return [s, s];
}

function StateMonad_State_set(v, _arg1) {
    return [void 0, v];
}

function StateMonad_State_map(f, s, s0) {
    const patternInput = s(s0);
    const state = patternInput[1];
    const retval = patternInput[0];
    return [f(retval), state];
}

export class StateMonad_StateBuilder {
    constructor() {
    }
}

export function StateMonad_StateBuilder$reflection() {
    return class_type("Common.StateMonad.StateBuilder", void 0, StateMonad_StateBuilder);
}

export function StateMonad_StateBuilder_$ctor() {
    return new StateMonad_StateBuilder();
}

export function StateMonad_StateBuilder__Return_1505(this$, x) {
    return (state) => [x, state];
}

export function StateMonad_StateBuilder__Zero(this$) {
    return (state) => StateMonad_StateBuilder__zero_1505(this$, state);
}

export function StateMonad_StateBuilder__ReturnFrom_1505(this$, stateful) {
    return stateful;
}

export function StateMonad_StateBuilder__Bind_3179(this$, m, f) {
    return (s) => StateMonad_StateBuilder__bind(this$, f, m, s);
}

export function StateMonad_StateBuilder__Combine_419033D3(this$, m1, m2) {
    return (s) => StateMonad_StateBuilder__bind(this$, uncurry(2, () => m2), m1, s);
}

export function StateMonad_StateBuilder__For_4BCC29DA(this$, seq, f) {
    return reduce((x1, x2) => StateMonad_StateBuilder__Combine_419033D3(this$, x1, x2), map_2(curry(2, f), seq));
}

export function StateMonad_StateBuilder__Delay_Z38F4EA44(this$, f) {
    return (s) => StateMonad_StateBuilder__bind(this$, f, (state) => StateMonad_StateBuilder__zero_1505(this$, state), s);
}

export function StateMonad_StateBuilder__While_Z13C36FDB(this$, condition, body) {
    return (state) => {
        const loop = (state_1_mut) => {
            loop:
            while (true) {
                const state_1 = state_1_mut;
                if (condition()) {
                    const state_2 = body(state_1)[1];
                    state_1_mut = state_2;
                    continue loop;
                }
                else {
                    return [void 0, state_1];
                }
                break;
            }
        };
        return loop(state);
    };
}

function StateMonad_StateBuilder__bind(this$, k, m, s) {
    const patternInput = m(s);
    const s$0027 = patternInput[1];
    const a = patternInput[0];
    return k(a, s$0027);
}

function StateMonad_StateBuilder__zero_1505(this$, state) {
    return [void 0, state];
}

export function StateMonad_get(unitVar0, state) {
    return [state, state];
}

export function StateMonad_getF(f, state) {
    return [f(state), state];
}

export function StateMonad_transform(f, state) {
    const state_1 = f(state);
    return [void 0, state_1];
}

export function StateMonad_transform1(f, state) {
    const patternInput = f(state);
    const state_1 = patternInput[1];
    const arg1 = patternInput[0];
    return [arg1, state_1];
}

export function StateMonad_set(v, state) {
    return [void 0, v];
}

export const StateMonad_stateChange = StateMonad_StateBuilder_$ctor();

export function StateMonad_runNoResult(state, m) {
    const state$0027 = m(state)[1];
    return state$0027;
}

export function withState(initialState, monad) {
    const result = monad(initialState)[0];
    return result;
}

export function toState(initialState, monad) {
    const finalState = monad(initialState)[1];
    return finalState;
}

export function $007CLookup$007C_$007C(key, map) {
    return tryFind(key, map);
}

//# sourceMappingURL=Common.fs.js.map
