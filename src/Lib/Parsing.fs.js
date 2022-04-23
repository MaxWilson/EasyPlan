import { FSharpRef, Record, Union } from "../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { option_type, record_type, class_type, tuple_type, string_type, union_type, int32_type, obj_type } from "../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { contains, ofSeq, FSharpSet_op_Addition, FSharpSet__Contains, FSharpSet__Add, FSharpSet__Remove, empty } from "../ShiningSword/fable_modules/fable-library.3.6.2/Set.js";
import { comparePrimitives, partialApply, compareArrays } from "../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { add, FSharpMap__Add, FSharpMap__TryFind, empty as empty_1 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { toFail, join, compare, printf, toText, substring } from "../ShiningSword/fable_modules/fable-library.3.6.2/String.js";
import { singleton, empty as empty_2, collect, delay, toList } from "../ShiningSword/fable_modules/fable-library.3.6.2/Seq.js";
import { some, value as value_9 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";
import { rangeChar } from "../ShiningSword/fable_modules/fable-library.3.6.2/Range.js";
import { tryParse } from "../ShiningSword/fable_modules/fable-library.3.6.2/Int32.js";

export class ParseResult extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Success", "Fail"];
    }
}

export function ParseResult$reflection() {
    return union_type("Packrat.ParseResult", [], ParseResult, () => [[["Item1", obj_type], ["Item2", int32_type]], []]);
}

export class ParseArgs extends Record {
    constructor(input, active, settled, externalContext) {
        super();
        this.input = input;
        this.active = active;
        this.settled = settled;
        this.externalContext = externalContext;
    }
}

export function ParseArgs$reflection() {
    return record_type("Packrat.ParseArgs", [], ParseArgs, () => [["input", string_type], ["active", record_type("Microsoft.FSharp.Core.FSharpRef`1", [class_type("Microsoft.FSharp.Collections.FSharpSet`1", [tuple_type(int32_type, int32_type)])], FSharpRef, () => [["contents", class_type("Microsoft.FSharp.Collections.FSharpSet`1", [tuple_type(int32_type, int32_type)])]])], ["settled", record_type("Microsoft.FSharp.Core.FSharpRef`1", [class_type("Microsoft.FSharp.Collections.FSharpMap`2", [tuple_type(int32_type, int32_type), ParseResult$reflection()])], FSharpRef, () => [["contents", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [tuple_type(int32_type, int32_type), ParseResult$reflection()])]])], ["externalContext", option_type(obj_type)]]);
}

export function ParseArgs_Init_Z1A8FAE6B(input, externalContext) {
    return [new ParseArgs(input, new FSharpRef(empty({
        Compare: (x, y) => compareArrays(x, y),
    })), new FSharpRef(empty_1()), externalContext), 0];
}

export function ParseInputModule_analyze(_arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const settled = _arg1[0].settled;
    const ix = _arg1[1] | 0;
    const input = _arg1[0].input;
    const distinguish = (startPos, afterPos, input_1) => {
        const before = substring(input_1, 0, startPos);
        const after = substring(input_1, afterPos);
        const mid = substring(input_1, startPos, afterPos - startPos);
        return toText(printf("%s\u003c\u003c\u003c%s\u003e\u003e\u003e%s"))(before)(mid)(after);
    };
    const results = toList(delay(() => collect((matchValue) => {
        let arg10_1;
        const activePatternResult13052 = matchValue;
        const startPos_1 = activePatternResult13052[0][0] | 0;
        const result = activePatternResult13052[1];
        const id = activePatternResult13052[0][1] | 0;
        if (result.tag === 1) {
            return empty_2();
        }
        else {
            const v = result.fields[0];
            const afterPos_1 = result.fields[1] | 0;
            return singleton((arg10_1 = distinguish(startPos_1, afterPos_1, input), toText(printf("%s %A"))(arg10_1)(v)));
        }
    }, settled.contents)));
    return ["..." + substring(input, ix), results];
}

export const ParseInputModule_$007CFailureAnalysis$007C = (tupledArg) => ParseInputModule_analyze(tupledArg[0], tupledArg[1]);

export function ExternalContextOf(_arg1_0, _arg1_1) {
    const x = _arg1_0;
    const matchValue = x.externalContext;
    if (matchValue != null) {
        const v = value_9(matchValue);
        return some(v);
    }
    else {
        return void 0;
    }
}

export const nextId = (() => {
    let i = 0;
    return () => {
        i = ((i + 1) | 0);
        return i | 0;
    };
})();

export function pack(rule) {
    const id = nextId() | 0;
    const eval$ = (input) => {
        const pos = input[1] | 0;
        const ctx = input[0];
        const active$0027 = ctx.active.contents;
        const key = [pos, id];
        ctx.active.contents = FSharpSet__Remove(ctx.active.contents, key);
        const matchValue = FSharpMap__TryFind(ctx.settled.contents, key);
        if (matchValue == null) {
            const settled = ctx.settled.contents;
            const active = ctx.active.contents;
            ctx.active.contents = FSharpSet__Add(active, key);
            ctx.settled.contents = FSharpMap__Add(settled, key, new ParseResult(1));
            const evalResult = rule([ctx, pos]);
            const hadLeftRecursion = !FSharpSet__Contains(ctx.active.contents, key);
            ctx.active.contents = FSharpSet__Remove(ctx.active.contents, key);
            const grow_1 = (seed, settled_1) => {
                const grow = (seed_1_mut, settled_2_mut) => {
                    let v_1, rest, oldendpos, endpos_1;
                    grow:
                    while (true) {
                        const seed_1 = seed_1_mut, settled_2 = settled_2_mut;
                        ctx.settled.contents = settled_2;
                        const matchValue_1 = [seed_1, rule([ctx, pos])];
                        let pattern_matching_result, endpos_2, v_2, endpos_3, oldendpos_1, rest_1, v_3;
                        if (matchValue_1[0] != null) {
                            if (matchValue_1[1] != null) {
                                if ((v_1 = matchValue_1[1][0], (rest = matchValue_1[1], (oldendpos = (matchValue_1[0][1] | 0), (endpos_1 = (matchValue_1[1][1][1] | 0), endpos_1 > oldendpos))))) {
                                    pattern_matching_result = 1;
                                    endpos_3 = matchValue_1[1][1][1];
                                    oldendpos_1 = matchValue_1[0][1];
                                    rest_1 = matchValue_1[1];
                                    v_3 = matchValue_1[1][0];
                                }
                                else {
                                    pattern_matching_result = 2;
                                }
                            }
                            else {
                                pattern_matching_result = 2;
                            }
                        }
                        else if (matchValue_1[1] != null) {
                            pattern_matching_result = 0;
                            endpos_2 = matchValue_1[1][1][1];
                            v_2 = matchValue_1[1][0];
                        }
                        else {
                            pattern_matching_result = 2;
                        }
                        switch (pattern_matching_result) {
                            case 0: {
                                seed_1_mut = [v_2, endpos_2];
                                settled_2_mut = add(key, new ParseResult(0, v_2, endpos_2), settled_2);
                                continue grow;
                            }
                            case 1: {
                                seed_1_mut = [v_3, endpos_3];
                                settled_2_mut = add(key, new ParseResult(0, v_3, endpos_3), settled_2);
                                continue grow;
                            }
                            case 2: {
                                if (matchValue_1[0] == null) {
                                    if (matchValue_1[1] == null) {
                                        return void 0;
                                    }
                                    else {
                                        throw (new Error("Match failure: Microsoft.FSharp.Core.FSharpOption`1"));
                                    }
                                }
                                else {
                                    const v_4 = matchValue_1[0][0];
                                    const endpos_4 = matchValue_1[0][1] | 0;
                                    return [v_4, endpos_4];
                                }
                            }
                        }
                        break;
                    }
                };
                const matchValue_2 = grow(seed, settled_1);
                if (matchValue_2 == null) {
                    ctx.settled.contents = add(key, new ParseResult(1), settled_1);
                    return void 0;
                }
                else {
                    const v_5 = matchValue_2[0];
                    const endpos_5 = matchValue_2[1] | 0;
                    ctx.settled.contents = add(key, new ParseResult(0, v_5, endpos_5), settled_1);
                    return [v_5, [ctx, endpos_5]];
                }
            };
            if (evalResult != null) {
                const v_6 = evalResult[0];
                const output = evalResult[1];
                const outpos = evalResult[1][1] | 0;
                const ctx_1 = evalResult[1][0];
                if (hadLeftRecursion) {
                    return grow_1([v_6, outpos], add(key, new ParseResult(0, v_6, outpos), settled));
                }
                else {
                    ctx_1.settled.contents = add(key, new ParseResult(0, v_6, outpos), ctx_1.settled.contents);
                    return [v_6, output];
                }
            }
            else if (hadLeftRecursion) {
                return grow_1(void 0, add(key, new ParseResult(1), settled));
            }
            else {
                ctx.settled.contents = add(key, new ParseResult(1), ctx.settled.contents);
                return void 0;
            }
        }
        else if (matchValue.tag === 1) {
            return void 0;
        }
        else {
            const endpos = matchValue.fields[1] | 0;
            const v = matchValue.fields[0];
            return [v, [ctx, endpos]];
        }
    };
    return eval$;
}

export function packrec(parseRule) {
    let f = (_arg1) => (void 0);
    f = pack(partialApply(1, parseRule, [(x) => f(x)]));
    return f;
}

export function $007CEnd$007C_$007C(_arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    if (ix === ctx.input.length) {
        return some(void 0);
    }
    else {
        return void 0;
    }
}

export function $007CStr$007C_$007C(str, _arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    if (((ix + str.length) <= ctx.input.length) && (compare(substring(ctx.input, ix, str.length), str, 3) === 0)) {
        return [ctx, ix + str.length];
    }
    else {
        return void 0;
    }
}

export function $007CPrecludeStr$007C_$007C(str, _arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    if (((ix + str.length) <= ctx.input.length) && (compare(substring(ctx.input, ix, str.length), str, 3) === 0)) {
        return void 0;
    }
    else {
        return [ctx, ix];
    }
}

export function $007CLookaheadStr$007C_$007C(str, _arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    if (((ix + str.length) <= ctx.input.length) && (compare(substring(ctx.input, ix, str.length), str, 3) === 0)) {
        return [ctx, ix];
    }
    else {
        return void 0;
    }
}

export function $007COptional$007C(str, _arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    if (((ix + str.length) <= ctx.input.length) && (compare(substring(ctx.input, ix, str.length), str, 3) === 0)) {
        return [ctx, ix + str.length];
    }
    else {
        return [ctx, ix];
    }
}

export const alpha = FSharpSet_op_Addition(ofSeq(toList(rangeChar("A", "Z")), {
    Compare: (x, y) => comparePrimitives(x, y),
}), ofSeq(toList(rangeChar("a", "z")), {
    Compare: (x_1, y_1) => comparePrimitives(x_1, y_1),
}));

export const numeric = ofSeq(toList(rangeChar("0", "9")), {
    Compare: (x, y) => comparePrimitives(x, y),
});

export const whitespace = ofSeq([" ", "\t", "\n", "\r"], {
    Compare: (x, y) => comparePrimitives(x, y),
});

export const alphanumeric = FSharpSet_op_Addition(alpha, numeric);

export const alphawhitespace = FSharpSet_op_Addition(alpha, whitespace);

export function $007CChar$007C_$007C(_arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    if (ix < ctx.input.length) {
        return [ctx.input[ix], [ctx, ix + 1]];
    }
    else {
        return void 0;
    }
}

export function $007CChars$007C_$007C(alphabet, _arg1_0, _arg1_1) {
    let endpos;
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    const seek = (i_mut) => {
        seek:
        while (true) {
            const i = i_mut;
            if ((i < ctx.input.length) && contains(ctx.input[i], alphabet)) {
                i_mut = (i + 1);
                continue seek;
            }
            else {
                return i | 0;
            }
            break;
        }
    };
    const matchValue = seek(ix) | 0;
    if ((endpos = (matchValue | 0), endpos > ix)) {
        const endpos_1 = matchValue | 0;
        return [substring(ctx.input, ix, endpos_1 - ix), [ctx, endpos_1]];
    }
    else {
        return void 0;
    }
}

export function readBetween(start_0, start_1, finish_0, finish_1) {
    const start = [start_0, start_1];
    const finish = [finish_0, finish_1];
    const ix = start[1] | 0;
    const ctx = start[0];
    const endIx = finish[1] | 0;
    return substring(ctx.input, ix, endIx - ix);
}

export function $007CCharsExcept$007C_$007C(exclusions, _arg1_0, _arg1_1) {
    let endpos;
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    const seek = (i_mut) => {
        seek:
        while (true) {
            const i = i_mut;
            if ((i < ctx.input.length) && (!contains(ctx.input[i], exclusions))) {
                i_mut = (i + 1);
                continue seek;
            }
            else {
                return i | 0;
            }
            break;
        }
    };
    const matchValue = seek(ix) | 0;
    if ((endpos = (matchValue | 0), endpos > ix)) {
        const endpos_1 = matchValue | 0;
        return [substring(ctx.input, ix, endpos_1 - ix), [ctx, endpos_1]];
    }
    else {
        return void 0;
    }
}

export function $007CLongestSubstringWhere$007C_$007C(pred, maxLength, _arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    const start = ix | 0;
    const seek = (i_mut, biggestMatch_mut) => {
        seek:
        while (true) {
            const i = i_mut, biggestMatch = biggestMatch_mut;
            const isMatch = () => pred(substring(ctx.input, start, i - start));
            if ((i <= ctx.input.length) && ((i - start) <= maxLength)) {
                if (isMatch()) {
                    i_mut = (i + 1);
                    biggestMatch_mut = i;
                    continue seek;
                }
                else if (biggestMatch != null) {
                    return biggestMatch;
                }
                else {
                    i_mut = (i + 1);
                    biggestMatch_mut = biggestMatch;
                    continue seek;
                }
            }
            else {
                return biggestMatch;
            }
            break;
        }
    };
    const matchValue = seek(ix, void 0);
    if (matchValue != null) {
        const endpos = matchValue | 0;
        return [substring(ctx.input, ix, endpos - ix), [ctx, endpos]];
    }
    else {
        return void 0;
    }
}

export function $007CAnyCase$007C(input) {
    return input.toLowerCase();
}

export function $007CAny$007C(_arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    return [substring(ctx.input, ix), [ctx, ctx.input.length]];
}

export function $007COWS$007C(_arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    const seek = (i_mut) => {
        seek:
        while (true) {
            const i = i_mut;
            if ((i < ctx.input.length) && contains(ctx.input[i], whitespace)) {
                i_mut = (i + 1);
                continue seek;
            }
            else {
                return i | 0;
            }
            break;
        }
    };
    return [ctx, seek(ix)];
}

export function $007CWS$007C_$007C(_arg1_0, _arg1_1) {
    let endx;
    const _arg1 = [_arg1_0, _arg1_1];
    const ix = _arg1[1] | 0;
    const ctx = _arg1[0];
    const seek = (i_mut) => {
        seek:
        while (true) {
            const i = i_mut;
            if ((i < ctx.input.length) && contains(ctx.input[i], whitespace)) {
                i_mut = (i + 1);
                continue seek;
            }
            else {
                return i | 0;
            }
            break;
        }
    };
    const matchValue = seek(ix) | 0;
    if ((endx = (matchValue | 0), endx > ix)) {
        const endx_1 = matchValue | 0;
        return [ctx, endx_1];
    }
    else {
        return void 0;
    }
}

export function $007COWSStr$007C_$007C(str, _arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const activePatternResult13102 = $007COWS$007C(_arg1[0], _arg1[1]);
    const activePatternResult13104 = $007CStr$007C_$007C(str, activePatternResult13102[0], activePatternResult13102[1]);
    if (activePatternResult13104 != null) {
        const ctx = activePatternResult13104;
        return ctx;
    }
    else {
        return void 0;
    }
}

export const $007CIntNoWhitespace$007C_$007C = pack((_arg1) => {
    const activePatternResult13108 = $007CChars$007C_$007C(numeric, _arg1[0], _arg1[1]);
    if (activePatternResult13108 != null) {
        const rest = activePatternResult13108[1];
        const v = activePatternResult13108[0];
        let matchValue;
        let outArg = 0;
        matchValue = [tryParse(v, 511, false, 32, new FSharpRef(() => outArg, (v_1) => {
            outArg = (v_1 | 0);
        })), outArg];
        if (matchValue[0]) {
            const v_2 = matchValue[1] | 0;
            return [v_2, rest];
        }
        else {
            return void 0;
        }
    }
    else {
        return void 0;
    }
});

export const $007CInt$007C_$007C = pack((_arg1) => {
    const activePatternResult13111 = $007COWS$007C(_arg1[0], _arg1[1]);
    const activePatternResult13113 = $007CChars$007C_$007C(numeric, activePatternResult13111[0], activePatternResult13111[1]);
    if (activePatternResult13113 != null) {
        let activePatternResult13114;
        const tupledArg = activePatternResult13113[1];
        activePatternResult13114 = $007COWS$007C(tupledArg[0], tupledArg[1]);
        const rest = activePatternResult13114;
        const v = activePatternResult13113[0];
        let matchValue;
        let outArg = 0;
        matchValue = [tryParse(v, 511, false, 32, new FSharpRef(() => outArg, (v_1) => {
            outArg = (v_1 | 0);
        })), outArg];
        if (matchValue[0]) {
            const v_2 = matchValue[1] | 0;
            return [v_2, rest];
        }
        else {
            return void 0;
        }
    }
    else {
        return void 0;
    }
});

export const $007CWord$007C_$007C = pack((_arg1) => {
    let activePatternResult13117, activePatternResult13119, activePatternResult13120, tupledArg, rest, v;
    return (activePatternResult13117 = $007COWS$007C(_arg1[0], _arg1[1]), (activePatternResult13119 = $007CChars$007C_$007C(alphanumeric, activePatternResult13117[0], activePatternResult13117[1]), (activePatternResult13119 != null) ? ((activePatternResult13120 = ((tupledArg = activePatternResult13119[1], $007COWS$007C(tupledArg[0], tupledArg[1]))), (rest = activePatternResult13120, (v = activePatternResult13119[0], [v, rest])))) : (void 0)));
});

export function $007CKeyword$007C_$007C(keyword, _arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    const activePatternResult13123 = $007COWS$007C(_arg1[0], _arg1[1]);
    const activePatternResult13125 = $007CStr$007C_$007C(keyword, activePatternResult13123[0], activePatternResult13123[1]);
    if (activePatternResult13125 != null) {
        let activePatternResult13126;
        const tupledArg = activePatternResult13125;
        activePatternResult13126 = $007COWS$007C(tupledArg[0], tupledArg[1]);
        const ctx = activePatternResult13126;
        return ctx;
    }
    else {
        return void 0;
    }
}

export const $007CWords$007C_$007C = packrec(($007CWords$007C_$007C_1, _arg1) => {
    let rest_1, w;
    let pattern_matching_result, ctx, endix, ix, rest;
    const activePatternResult13130 = $007CWords$007C_$007C_1(_arg1);
    if (activePatternResult13130 != null) {
        const activePatternResult13131 = $007CWord$007C_$007C(activePatternResult13130[1]);
        if (activePatternResult13131 != null) {
            pattern_matching_result = 0;
            ctx = _arg1[0];
            endix = activePatternResult13131[1][1];
            ix = _arg1[1];
            rest = activePatternResult13131[1];
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
            const txt = substring(ctx.input, ix, endix - ix).trim();
            return [txt, rest];
        }
        case 1: {
            const activePatternResult13129 = $007CWord$007C_$007C(_arg1);
            return (activePatternResult13129 != null) ? ((rest_1 = activePatternResult13129[1], (w = activePatternResult13129[0], [w, rest_1]))) : (void 0);
        }
    }
});

export function parser(recognizerRoot, txt) {
    let tupledArg;
    const $007CRoot$007C_$007C = recognizerRoot;
    const matchValue = ParseArgs_Init_Z1A8FAE6B(txt);
    let pattern_matching_result, v;
    const activePatternResult13136 = $007CRoot$007C_$007C(matchValue);
    if (activePatternResult13136 != null) {
        if (((tupledArg = activePatternResult13136[1], $007CEnd$007C_$007C(tupledArg[0], tupledArg[1]))) != null) {
            pattern_matching_result = 0;
            v = activePatternResult13136[0];
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
            return v;
        }
        case 1: {
            const analysis = ParseInputModule_$007CFailureAnalysis$007C(matchValue)[1];
            const arg20 = join("\n", analysis);
            return toFail(printf("Could not parse \u0027%s\u0027\nSuccessful matches: %s"))(txt)(arg20);
        }
    }
}

export function parserWithExternalContext(recognizerRoot, ctx, txt) {
    let tupledArg;
    const $007CRoot$007C_$007C = recognizerRoot;
    const matchValue = ParseArgs_Init_Z1A8FAE6B(txt, some(ctx));
    let pattern_matching_result, v;
    const activePatternResult13143 = $007CRoot$007C_$007C(matchValue);
    if (activePatternResult13143 != null) {
        if (((tupledArg = activePatternResult13143[1], $007CEnd$007C_$007C(tupledArg[0], tupledArg[1]))) != null) {
            pattern_matching_result = 0;
            v = activePatternResult13143[0];
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
            return v;
        }
        case 1: {
            const analysis = ParseInputModule_$007CFailureAnalysis$007C(matchValue)[1];
            const arg20 = join("\n", analysis);
            return toFail(printf("Could not parse \u0027%s\u0027\nSuccessful matches: %s"))(txt)(arg20);
        }
    }
}

//# sourceMappingURL=Parsing.fs.js.map
