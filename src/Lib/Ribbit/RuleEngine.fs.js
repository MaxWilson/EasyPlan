import { value as value_1 } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";
import { toString } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { ofSeq, filter, fold, singleton, cons, collect, map, head, tail, empty, isEmpty, append } from "../../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { FSharpResult$2 } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Choice.js";
import { Ribbit0_Api$1, Ribbit0_Scope, Ribbit0_Event, Ribbit0_EventState, Ribbit0_EventDefinition, Ribbit0_RibbitRuntimeException_$ctor_Z721C83C5, Ribbit0_Game, Ribbit0_ExecutionContext_get_fresh, Ribbit0_VariableReference, Ribbit0_ExecutionContext, Ribbit0_Statement, Ribbit0_Expression, Ribbit0_RuntimeValue } from "./Model.fs.js";
import { notImpl, shouldntHappen } from "../Common.fs.js";
import { ofSeq as ofSeq_1, remove, ofList as ofList_1, containsKey, tryFind, add, change, empty as empty_1 } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { add as add_1, ofList } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Set.js";
import { equalArrays, comparePrimitives } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";

export function describeId(_arg1) {
    if (_arg1 != null) {
        const v = value_1(_arg1);
        let copyOfStruct = v;
        return toString(copyOfStruct);
    }
    else {
        return "None";
    }
}

export function evaluate(api, ctx, state, expr) {
    const eval$ = (_arg1) => {
        switch (_arg1.tag) {
            case 1: {
                const rhs = _arg1.fields[1];
                const op = _arg1.fields[2];
                const lhs = _arg1.fields[0];
                const matchValue = [eval$(lhs), eval$(rhs)];
                const copyOfStruct = matchValue[0];
                if (copyOfStruct.tag === 1) {
                    const copyOfStruct_1 = matchValue[1];
                    if (copyOfStruct_1.tag === 1) {
                        const lhs_15 = copyOfStruct.fields[0];
                        const rhs_15 = copyOfStruct_1.fields[0];
                        return new FSharpResult$2(1, append(lhs_15, rhs_15));
                    }
                    else {
                        const lhs_14 = matchValue[0];
                        return lhs_14;
                    }
                }
                else {
                    const copyOfStruct_2 = matchValue[1];
                    if (copyOfStruct_2.tag === 1) {
                        const rhs_14 = matchValue[1];
                        return rhs_14;
                    }
                    else {
                        const lhs_1 = copyOfStruct.fields[0];
                        const rhs_1 = copyOfStruct_2.fields[0];
                        const binary = (_arg2) => {
                            let pattern_matching_result, lhs_2, rhs_2, lhs_3, rhs_3, lhs_4, rhs_4, lhs_5, rhs_5, lhs_6, rhs_6, lhs_7, rhs_7, lhs_8, rhs_8, lhs_9, rhs_9, lhs_10, rhs_10, lhs_11, rhs_11, lhs_12, rhs_12, lhs_13, rhs_13;
                            if (_arg2[0].tag === 0) {
                                if (_arg2[1].tag === 0) {
                                    if (_arg2[2].tag === 0) {
                                        pattern_matching_result = 0;
                                        lhs_2 = _arg2[0].fields[0];
                                        rhs_2 = _arg2[1].fields[0];
                                    }
                                    else if (_arg2[2].tag === 4) {
                                        pattern_matching_result = 8;
                                        lhs_10 = _arg2[0].fields[0];
                                        rhs_10 = _arg2[1].fields[0];
                                    }
                                    else {
                                        pattern_matching_result = 12;
                                    }
                                }
                                else {
                                    pattern_matching_result = 12;
                                }
                            }
                            else if (_arg2[0].tag === 1) {
                                if (_arg2[1].tag === 1) {
                                    if (_arg2[2].tag === 1) {
                                        pattern_matching_result = 3;
                                        lhs_5 = _arg2[0].fields[0];
                                        rhs_5 = _arg2[1].fields[0];
                                    }
                                    else if (_arg2[2].tag === 2) {
                                        pattern_matching_result = 4;
                                        lhs_6 = _arg2[0].fields[0];
                                        rhs_6 = _arg2[1].fields[0];
                                    }
                                    else if (_arg2[2].tag === 3) {
                                        pattern_matching_result = 6;
                                        lhs_8 = _arg2[0].fields[0];
                                        rhs_8 = _arg2[1].fields[0];
                                    }
                                    else if (_arg2[2].tag === 4) {
                                        pattern_matching_result = 7;
                                        lhs_9 = _arg2[0].fields[0];
                                        rhs_9 = _arg2[1].fields[0];
                                    }
                                    else if (_arg2[2].tag === 5) {
                                        pattern_matching_result = 10;
                                        lhs_12 = _arg2[0].fields[0];
                                        rhs_12 = _arg2[1].fields[0];
                                    }
                                    else if (_arg2[2].tag === 6) {
                                        pattern_matching_result = 11;
                                        lhs_13 = _arg2[0].fields[0];
                                        rhs_13 = _arg2[1].fields[0];
                                    }
                                    else {
                                        pattern_matching_result = 1;
                                        lhs_3 = _arg2[0].fields[0];
                                        rhs_3 = _arg2[1].fields[0];
                                    }
                                }
                                else {
                                    pattern_matching_result = 12;
                                }
                            }
                            else if (_arg2[0].tag === 2) {
                                if (_arg2[1].tag === 2) {
                                    if (_arg2[2].tag === 0) {
                                        pattern_matching_result = 2;
                                        lhs_4 = _arg2[0].fields[0];
                                        rhs_4 = _arg2[1].fields[0];
                                    }
                                    else if (_arg2[2].tag === 2) {
                                        pattern_matching_result = 5;
                                        lhs_7 = _arg2[0].fields[0];
                                        rhs_7 = _arg2[1].fields[0];
                                    }
                                    else if (_arg2[2].tag === 4) {
                                        pattern_matching_result = 9;
                                        lhs_11 = _arg2[0].fields[0];
                                        rhs_11 = _arg2[1].fields[0];
                                    }
                                    else {
                                        pattern_matching_result = 12;
                                    }
                                }
                                else {
                                    pattern_matching_result = 12;
                                }
                            }
                            else {
                                pattern_matching_result = 12;
                            }
                            switch (pattern_matching_result) {
                                case 0: {
                                    return new Ribbit0_RuntimeValue(0, lhs_2 + rhs_2);
                                }
                                case 1: {
                                    return new Ribbit0_RuntimeValue(1, lhs_3 + rhs_3);
                                }
                                case 2: {
                                    return new Ribbit0_RuntimeValue(2, lhs_4 ? true : rhs_4);
                                }
                                case 3: {
                                    return new Ribbit0_RuntimeValue(1, lhs_5 - rhs_5);
                                }
                                case 4: {
                                    return new Ribbit0_RuntimeValue(1, lhs_6 * rhs_6);
                                }
                                case 5: {
                                    return new Ribbit0_RuntimeValue(2, lhs_7 && rhs_7);
                                }
                                case 6: {
                                    return new Ribbit0_RuntimeValue(1, ~(~(lhs_8 / rhs_8)));
                                }
                                case 7: {
                                    return new Ribbit0_RuntimeValue(2, lhs_9 === rhs_9);
                                }
                                case 8: {
                                    return new Ribbit0_RuntimeValue(2, lhs_10 === rhs_10);
                                }
                                case 9: {
                                    return new Ribbit0_RuntimeValue(2, lhs_11 === rhs_11);
                                }
                                case 10: {
                                    return new Ribbit0_RuntimeValue(2, lhs_12 >= rhs_12);
                                }
                                case 11: {
                                    return new Ribbit0_RuntimeValue(2, lhs_13 <= rhs_13);
                                }
                                case 12: {
                                    return new Ribbit0_RuntimeValue(4);
                                }
                            }
                        };
                        return new FSharpResult$2(0, binary([lhs_1, rhs_1, op]));
                    }
                }
            }
            case 2: {
                const ref = _arg1.fields[0];
                return api.dereference(ctx, ref, state);
            }
            case 3:
            case 4: {
                return new FSharpResult$2(0, new Ribbit0_RuntimeValue(4));
            }
            default: {
                const v = _arg1.fields[0];
                return new FSharpResult$2(0, v);
            }
        }
    };
    return eval$(expr);
}

export function execute(api, ctx, state, statements) {
    const evalApi = {
        dereference: api.dereference,
    };
    const eval$ = (ctx_1, state_1, expr) => evaluate(api, ctx_1, state_1, expr);
    const loop = (state_2_mut, ctx_2_mut, statements_1_mut) => {
        loop:
        while (true) {
            const state_2 = state_2_mut, ctx_2 = ctx_2_mut, statements_1 = statements_1_mut;
            if (isEmpty(statements_1)) {
                return [state_2, empty(), new FSharpResult$2(0, new Ribbit0_RuntimeValue(4)), ctx_2];
            }
            else {
                const stack = statements_1;
                const rest = tail(statements_1);
                const current = head(statements_1);
                if (current.tag === 1) {
                    if (current.fields[1].tag === 4) {
                        const args = current.fields[1].fields[1];
                        const eventName = current.fields[1].fields[0];
                        const ref = current.fields[0];
                        const args_1 = map((tupledArg) => {
                            const name = tupledArg[0];
                            const expr_2 = tupledArg[1];
                            return [name, eval$(ctx_2, state_2, expr_2)];
                        }, args);
                        const awaiting_2 = collect((_arg1) => {
                            const copyOfStruct = _arg1[1];
                            if (copyOfStruct.tag === 1) {
                                const awaiting_1 = copyOfStruct.fields[0];
                                return awaiting_1;
                            }
                            else {
                                return empty();
                            }
                        }, args_1);
                        if (isEmpty(awaiting_2)) {
                            const actualParameters = map((_arg2) => {
                                const copyOfStruct_1 = _arg2[1];
                                if (copyOfStruct_1.tag === 0) {
                                    const name_1 = _arg2[0];
                                    const v_1 = copyOfStruct_1.fields[0];
                                    return [name_1, v_1];
                                }
                                else {
                                    return shouldntHappen();
                                }
                            }, args_1);
                            const patternInput = api.start(eventName, actualParameters, state_2);
                            const state_3 = patternInput[1];
                            const eventId = patternInput[0] | 0;
                            state_2_mut = state_3;
                            ctx_2_mut = ctx_2;
                            statements_1_mut = cons(new Ribbit0_Statement(1, ref, new Ribbit0_Expression(0, new Ribbit0_RuntimeValue(3, eventId))), rest);
                            continue loop;
                        }
                        else {
                            const awaiting_3 = awaiting_2;
                            return [state_2, stack, new FSharpResult$2(1, awaiting_3), ctx_2];
                        }
                    }
                    else {
                        const expr_3 = current.fields[1];
                        const ref_1 = current.fields[0];
                        const matchValue_1 = eval$(ctx_2, state_2, expr_3);
                        if (matchValue_1.tag === 0) {
                            const v_2 = matchValue_1.fields[0];
                            const patternInput_1 = api.supply(ctx_2, ref_1, v_2, state_2);
                            const unblocked = patternInput_1[1];
                            const state_4 = patternInput_1[0];
                            const ctx_3 = new Ribbit0_ExecutionContext(append(unblocked, ctx_2.workQueue), ctx_2.currentEvent);
                            state_2_mut = state_4;
                            ctx_2_mut = ctx_3;
                            statements_1_mut = rest;
                            continue loop;
                        }
                        else {
                            const awaiting_4 = matchValue_1;
                            return [state_2, stack, awaiting_4, ctx_2];
                        }
                    }
                }
                else if (current.tag === 2) {
                    const statements_2 = current.fields[0];
                    state_2_mut = state_2;
                    ctx_2_mut = ctx_2;
                    statements_1_mut = append(statements_2, rest);
                    continue loop;
                }
                else if (current.tag === 3) {
                    const andThen = current.fields[1];
                    const orElse = current.fields[2];
                    const test = current.fields[0];
                    const matchValue_2 = eval$(ctx_2, state_2, test);
                    if (matchValue_2.tag === 0) {
                        if (matchValue_2.fields[0].tag === 2) {
                            if (matchValue_2.fields[0].fields[0]) {
                                state_2_mut = state_2;
                                ctx_2_mut = ctx_2;
                                statements_1_mut = cons(andThen, rest);
                                continue loop;
                            }
                            else if (orElse != null) {
                                const expr_4 = orElse;
                                state_2_mut = state_2;
                                ctx_2_mut = ctx_2;
                                statements_1_mut = cons(expr_4, rest);
                                continue loop;
                            }
                            else {
                                state_2_mut = state_2;
                                ctx_2_mut = ctx_2;
                                statements_1_mut = rest;
                                continue loop;
                            }
                        }
                        else {
                            return shouldntHappen();
                        }
                    }
                    else {
                        const awaiting_5 = matchValue_2;
                        return [state_2, stack, awaiting_5, ctx_2];
                    }
                }
                else {
                    const expr_1 = current.fields[0];
                    const matchValue = eval$(ctx_2, state_2, expr_1);
                    if (matchValue.tag === 0) {
                        const v = matchValue.fields[0];
                        return [state_2, empty(), new FSharpResult$2(0, v), ctx_2];
                    }
                    else {
                        const awaiting = matchValue;
                        return [state_2, singleton(current), awaiting, ctx_2];
                    }
                }
            }
            break;
        }
    };
    return loop(state, ctx, statements);
}

export function progressToFixedPoint(api, state, ctx) {
    let queue = ctx.workQueue;
    let state_1 = state;
    while (!isEmpty(queue)) {
        if (!isEmpty(queue)) {
            const rest = tail(queue);
            const currentEvent = head(queue) | 0;
            queue = rest;
            const statements = api.resume(currentEvent, state_1);
            const matchValue = execute(api, new Ribbit0_ExecutionContext(empty(), currentEvent), state_1, statements);
            const copyOfStruct = matchValue[2];
            if (copyOfStruct.tag === 1) {
                const ctx_2 = matchValue[3];
                const dependencies = copyOfStruct.fields[0];
                const state$0027_2 = matchValue[0];
                const statements_1 = matchValue[1];
                state_1 = api.defer(currentEvent, statements_1, dependencies, state$0027_2);
            }
            else {
                const ctx_1 = matchValue[3];
                const state$0027 = matchValue[0];
                const v = copyOfStruct.fields[0];
                const matchValue_1 = api.supply(new Ribbit0_ExecutionContext(empty(), currentEvent), new Ribbit0_VariableReference(2, currentEvent), v, state$0027);
                const unblockedWorkItems = matchValue_1[1];
                const state$0027_1 = matchValue_1[0];
                state_1 = state$0027_1;
                queue = append(ctx_1.workQueue, append(unblockedWorkItems, queue));
            }
        }
    }
    return state_1;
}

export function query(api, state) {
    return notImpl();
}

export function supply(api, agent, property, v, state) {
    const patternInput = api.supply(Ribbit0_ExecutionContext_get_fresh(), new Ribbit0_VariableReference(0, agent, property), v, state);
    const unblocked = patternInput[1];
    const state_1 = patternInput[0];
    return progressToFixedPoint(api, state_1, new Ribbit0_ExecutionContext(unblocked, Ribbit0_ExecutionContext_get_fresh().currentEvent));
}

export const Game_fresh = new Ribbit0_Game(empty_1(), empty_1(), empty_1(), empty_1(), empty_1(), 1, 1, empty_1(), empty());

export function Game_add(name, g) {
    const patternInput = [g.nextAgentId, new Ribbit0_Game(g.roster, g.rosterReverse, g.data, g.eventDefinitions, g.events, g.nextAgentId + 1, g.nextEventId, g.waitingEvents, g.dataDependencies)];
    const id = patternInput[0] | 0;
    const g_1 = patternInput[1];
    return [id, new Ribbit0_Game(change(name, (_arg1) => {
        if (_arg1 == null) {
            return singleton(id);
        }
        else {
            const ids = _arg1;
            return cons(id, ids);
        }
    }, g_1.roster), add(id, name, g_1.rosterReverse), g_1.data, g_1.eventDefinitions, g_1.events, g_1.nextAgentId, g_1.nextEventId, g_1.waitingEvents, g_1.dataDependencies)];
}

export function Game_dereference(ctx_mut, ref_mut, g_mut) {
    Game_dereference:
    while (true) {
        const ctx = ctx_mut, ref = ref_mut, g = g_mut;
        switch (ref.tag) {
            case 3: {
                const propName_1 = ref.fields[1];
                const agentIdRef = ref.fields[0];
                const matchValue_2 = Game_dereference(ctx, new Ribbit0_VariableReference(1, agentIdRef), g);
                if (matchValue_2.tag === 0) {
                    if (matchValue_2.fields[0].tag === 3) {
                        const agentId_1 = matchValue_2.fields[0].fields[0] | 0;
                        ctx_mut = ctx;
                        ref_mut = (new Ribbit0_VariableReference(0, agentId_1, propName_1));
                        g_mut = g;
                        continue Game_dereference;
                    }
                    else {
                        const agentId_2 = matchValue_2.fields[0];
                        const exn = Ribbit0_RibbitRuntimeException_$ctor_Z721C83C5(`${agentIdRef} (${agentId_2}) is not a valid agentId`);
                        throw exn;
                    }
                }
                else {
                    const error = matchValue_2;
                    return error;
                }
            }
            case 4: {
                const eventIdRef = ref.fields[0];
                const matchValue_3 = Game_dereference(ctx, new Ribbit0_VariableReference(1, eventIdRef), g);
                if (matchValue_3.tag === 0) {
                    if (matchValue_3.fields[0].tag === 3) {
                        const eventId = matchValue_3.fields[0].fields[0] | 0;
                        ctx_mut = ctx;
                        ref_mut = (new Ribbit0_VariableReference(2, eventId));
                        g_mut = g;
                        continue Game_dereference;
                    }
                    else {
                        const eventId_1 = matchValue_3.fields[0];
                        const exn_1 = Ribbit0_RibbitRuntimeException_$ctor_Z721C83C5(`${eventId_1} is not a valid eventId`);
                        throw exn_1;
                    }
                }
                else {
                    const error_1 = matchValue_3;
                    return error_1;
                }
            }
            case 1: {
                const guid = ref.fields[0];
                const matchValue_4 = ctx.currentEvent;
                if (matchValue_4 != null) {
                    const eventId_2 = matchValue_4 | 0;
                    const matchValue_5 = tryFind(eventId_2, g.events);
                    let pattern_matching_result, state;
                    if (matchValue_5 != null) {
                        if (matchValue_5.tag === 1) {
                            pattern_matching_result = 0;
                            state = matchValue_5.fields[0];
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
                            const matchValue_6 = tryFind(guid, state.scope.properties);
                            if (matchValue_6 != null) {
                                const v_1 = matchValue_6;
                                return new FSharpResult$2(0, v_1);
                            }
                            else {
                                return new FSharpResult$2(1, singleton(ref));
                            }
                        }
                        case 1: {
                            return shouldntHappen();
                        }
                    }
                }
                else {
                    return shouldntHappen();
                }
            }
            case 2: {
                const eventId_3 = ref.fields[0] | 0;
                const matchValue_7 = tryFind(eventId_3, g.events);
                if (matchValue_7 == null) {
                    return shouldntHappen();
                }
                else if (matchValue_7.tag === 0) {
                    const v_2 = matchValue_7.fields[0];
                    return new FSharpResult$2(0, v_2);
                }
                else {
                    const state_1 = matchValue_7.fields[0];
                    return new FSharpResult$2(1, singleton(ref));
                }
            }
            default: {
                const propName = ref.fields[1];
                const agentId = ref.fields[0] | 0;
                const matchValue = tryFind(agentId, g.data);
                if (matchValue != null) {
                    const scope = matchValue;
                    const matchValue_1 = tryFind(propName, scope.properties);
                    if (matchValue_1 != null) {
                        const v = matchValue_1;
                        return new FSharpResult$2(0, v);
                    }
                    else {
                        return new FSharpResult$2(1, singleton(ref));
                    }
                }
                else {
                    return new FSharpResult$2(1, singleton(ref));
                }
            }
        }
        break;
    }
}

export function Game_define(eventName, instructions, g) {
    return new Ribbit0_Game(g.roster, g.rosterReverse, g.data, add(eventName, new Ribbit0_EventDefinition(eventName, empty(), instructions), g.eventDefinitions), g.events, g.nextAgentId, g.nextEventId, g.waitingEvents, g.dataDependencies);
}

export function Game_defer(eventId, statements, refs, g) {
    const updatedEvents = change(eventId, (_arg1) => {
        let pattern_matching_result, state, v;
        if (_arg1 != null) {
            if (_arg1.tag === 1) {
                pattern_matching_result = 0;
                state = _arg1.fields[0];
            }
            else {
                pattern_matching_result = 1;
                v = _arg1;
            }
        }
        else {
            pattern_matching_result = 1;
            v = _arg1;
        }
        switch (pattern_matching_result) {
            case 0: {
                return new Ribbit0_Event(1, new Ribbit0_EventState(state.scope, statements));
            }
            case 1: {
                return v;
            }
        }
    }, g.events);
    const updateRef = (g_1, ref) => {
        let propertyName, agentId;
        return new Ribbit0_Game(g_1.roster, g_1.rosterReverse, g_1.data, g_1.eventDefinitions, g_1.events, g_1.nextAgentId, g_1.nextEventId, change(ref, (_arg2) => {
            if (_arg2 == null) {
                return ofList(singleton(eventId), {
                    Compare: (x, y) => comparePrimitives(x, y),
                });
            }
            else {
                const lst = _arg2;
                return add_1(eventId, lst);
            }
        }, g_1.waitingEvents), (ref.tag === 0) ? ((propertyName = ref.fields[1], (agentId = (ref.fields[0] | 0), containsKey(ref, g_1.waitingEvents) ? g_1.dataDependencies : append(g_1.dataDependencies, singleton([agentId, propertyName]))))) : g_1.dataDependencies);
    };
    return fold(updateRef, new Ribbit0_Game(g.roster, g.rosterReverse, g.data, g.eventDefinitions, updatedEvents, g.nextAgentId, g.nextEventId, g.waitingEvents, g.dataDependencies), refs);
}

export function Game_set(ctx_mut, ref_mut, value_mut, g_mut) {
    Game_set:
    while (true) {
        const ctx = ctx_mut, ref = ref_mut, value = value_mut, g = g_mut;
        switch (ref.tag) {
            case 3: {
                const propName_1 = ref.fields[1];
                const agentIdRef = ref.fields[0];
                const matchValue = Game_dereference(ctx, new Ribbit0_VariableReference(1, agentIdRef), g);
                if (matchValue.tag === 0) {
                    const agentId_1 = matchValue.fields[0];
                    if (agentId_1.tag === 3) {
                        const agentId_2 = agentId_1.fields[0] | 0;
                        ctx_mut = ctx;
                        ref_mut = (new Ribbit0_VariableReference(0, agentId_2, propName_1));
                        value_mut = value;
                        g_mut = g;
                        continue Game_set;
                    }
                    else {
                        const exn = Ribbit0_RibbitRuntimeException_$ctor_Z721C83C5(`${agentIdRef} (${agentId_1}) is not a valid agentId`);
                        throw exn;
                    }
                }
                else {
                    const error = matchValue;
                    return notImpl();
                }
            }
            case 1: {
                const propName_2 = ref.fields[0];
                let events;
                const matchValue_1 = ctx.currentEvent;
                if (matchValue_1 != null) {
                    const eventId = matchValue_1 | 0;
                    events = change(eventId, (_arg2) => {
                        let pattern_matching_result, state;
                        if (_arg2 != null) {
                            if (_arg2.tag === 1) {
                                pattern_matching_result = 0;
                                state = _arg2.fields[0];
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
                                const scope_1 = new Ribbit0_Scope(add(propName_2, value, state.scope.properties));
                                return new Ribbit0_Event(1, new Ribbit0_EventState(scope_1, state.instructionStack));
                            }
                            case 1: {
                                const exn_1 = Ribbit0_RibbitRuntimeException_$ctor_Z721C83C5("Can\u0027t set variable on an event that doesn\u0027t exist yet");
                                throw exn_1;
                            }
                        }
                    }, g.events);
                }
                else {
                    events = shouldntHappen();
                }
                return new Ribbit0_Game(g.roster, g.rosterReverse, g.data, g.eventDefinitions, events, g.nextAgentId, g.nextEventId, g.waitingEvents, g.dataDependencies);
            }
            case 2: {
                const eventId_1 = ref.fields[0] | 0;
                const events_1 = change(eventId_1, (_arg3) => {
                    let pattern_matching_result_1;
                    if (_arg3 != null) {
                        if (_arg3.tag === 1) {
                            pattern_matching_result_1 = 0;
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
                            return new Ribbit0_Event(0, value);
                        }
                        case 1: {
                            return shouldntHappen();
                        }
                    }
                }, g.events);
                return new Ribbit0_Game(g.roster, g.rosterReverse, g.data, g.eventDefinitions, events_1, g.nextAgentId, g.nextEventId, g.waitingEvents, g.dataDependencies);
            }
            case 4: {
                return shouldntHappen();
            }
            default: {
                const propName = ref.fields[1];
                const agentId = ref.fields[0] | 0;
                const data = change(agentId, (_arg1) => {
                    if (_arg1 != null) {
                        const scope = _arg1;
                        return new Ribbit0_Scope(add(propName, value, scope.properties));
                    }
                    else {
                        return new Ribbit0_Scope(ofList_1(singleton([propName, value])));
                    }
                }, g.data);
                return new Ribbit0_Game(g.roster, g.rosterReverse, data, g.eventDefinitions, g.events, g.nextAgentId, g.nextEventId, g.waitingEvents, g.dataDependencies);
            }
        }
        break;
    }
}

export function Game_supply(ctx, ref, value, g) {
    const matchValue = tryFind(ref, g.waitingEvents);
    if (matchValue != null) {
        const dependencies = matchValue;
        const g_1 = new Ribbit0_Game(g.roster, g.rosterReverse, g.data, g.eventDefinitions, g.events, g.nextAgentId, g.nextEventId, remove(ref, g.waitingEvents), g.dataDependencies);
        let g_2;
        if (ref.tag === 0) {
            const propName = ref.fields[1];
            const agentId = ref.fields[0] | 0;
            const dd = filter((y) => (!equalArrays([agentId, propName], y)), g_1.dataDependencies);
            g_2 = (new Ribbit0_Game(g_1.roster, g_1.rosterReverse, g_1.data, g_1.eventDefinitions, g_1.events, g_1.nextAgentId, g_1.nextEventId, g_1.waitingEvents, dd));
        }
        else {
            g_2 = g_1;
        }
        return [Game_set(ctx, ref, value, g_2), ofSeq(dependencies)];
    }
    else {
        return [Game_set(ctx, ref, value, g), empty()];
    }
}

export function Game_resume(eventId, g) {
    const matchValue = tryFind(eventId, g.events);
    let pattern_matching_result, state;
    if (matchValue != null) {
        if (matchValue.tag === 1) {
            pattern_matching_result = 0;
            state = matchValue.fields[0];
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
            return state.instructionStack;
        }
        case 1: {
            return shouldntHappen();
        }
    }
}

export function Game_runEvent(eventId, g) {
    return progressToFixedPoint(Game_api, g, new Ribbit0_ExecutionContext(singleton(eventId), eventId));
}

export function Game_start(instructions, args, g) {
    const patternInput = [g.nextEventId, new Ribbit0_Game(g.roster, g.rosterReverse, g.data, g.eventDefinitions, g.events, g.nextAgentId, g.nextEventId + 1, g.waitingEvents, g.dataDependencies)];
    const g_1 = patternInput[1];
    const eventId = patternInput[0] | 0;
    const g_2 = new Ribbit0_Game(g_1.roster, g_1.rosterReverse, g_1.data, g_1.eventDefinitions, change(eventId, (_arg1) => {
        if (_arg1 == null) {
            return new Ribbit0_Event(1, new Ribbit0_EventState(new Ribbit0_Scope(ofSeq_1(args)), instructions));
        }
        else {
            return shouldntHappen();
        }
    }, g_1.events), g_1.nextAgentId, g_1.nextEventId, g_1.waitingEvents, g_1.dataDependencies);
    return [eventId, Game_runEvent(eventId, g_2)];
}

export function Game_startByName(name, args, g) {
    const matchValue = tryFind(name, g.eventDefinitions);
    if (matchValue == null) {
        const exn = Ribbit0_RibbitRuntimeException_$ctor_Z721C83C5(`No such event: '${name}'`);
        throw exn;
    }
    else {
        const def = matchValue;
        const patternInput = Game_start(def.instructions, args, g);
        const g_1 = patternInput[1];
        const eventId = patternInput[0] | 0;
        return [eventId, g_1];
    }
}

export const Game_api = new Ribbit0_Api$1((ctx, ref, g) => Game_dereference(ctx, ref, g), (eventId, statements, refs, g_1) => Game_defer(eventId, statements, refs, g_1), (eventId_1, g_2) => Game_resume(eventId_1, g_2), (ctx_1, ref_1, value, g_3) => Game_supply(ctx_1, ref_1, value, g_3), (name, args, g_4) => Game_startByName(name, args, g_4));

export function compile() {
    return (x) => x;
}

//# sourceMappingURL=RuleEngine.fs.js.map
