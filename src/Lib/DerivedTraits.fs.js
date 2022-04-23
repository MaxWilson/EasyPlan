import { Record } from "../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { record_type, int32_type, option_type, lambda_type, bool_type, tuple_type, class_type, array_type } from "../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { singleton as singleton_1, length } from "../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { ofList, change as change_1, FSharpMap__get_Item, add, tryFind, empty } from "../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { numberHash, compare, equals, getEnumerator } from "../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { take, contains, mapIndexed, map, append } from "../ShiningSword/fable_modules/fable-library.3.6.2/Array.js";
import { singleton, empty as empty_1, append as append_1, collect as collect_1, delay, toList } from "../ShiningSword/fable_modules/fable-library.3.6.2/Seq.js";
import { shouldntHappen, tuple2, thunk, $007CLookup$007C_$007C } from "./Common.fs.js";
import { empty as empty_2, ofSeq } from "../ShiningSword/fable_modules/fable-library.3.6.2/Set.js";
import { value as value_2 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";
import { join } from "../ShiningSword/fable_modules/fable-library.3.6.2/String.js";
import { Array_distinct } from "../ShiningSword/fable_modules/fable-library.3.6.2/Seq2.js";

export class Choice$2 extends Record {
    constructor(options, preconditions, numberAllowed, mustBeDistinct, elideFromDisplayAndSummary, autopick) {
        super();
        this.options = options;
        this.preconditions = preconditions;
        this.numberAllowed = (numberAllowed | 0);
        this.mustBeDistinct = mustBeDistinct;
        this.elideFromDisplayAndSummary = elideFromDisplayAndSummary;
        this.autopick = autopick;
    }
}

export function Choice$2$reflection(gen0, gen1) {
    return record_type("DerivedTraits.Choice`2", [gen0, gen1], Choice$2, () => [["options", array_type(gen0)], ["preconditions", option_type(lambda_type(tuple_type(gen0, tuple_type(class_type("Microsoft.FSharp.Collections.FSharpSet`1", [gen0]), gen1)), bool_type))], ["numberAllowed", int32_type], ["mustBeDistinct", bool_type], ["elideFromDisplayAndSummary", bool_type], ["autopick", bool_type]]);
}

export function fresh(options) {
    return new Choice$2(Array.from(options), void 0, 1, false, false, false);
}

export class Setting$2 extends Record {
    constructor(instance, summary) {
        super();
        this.instance = instance;
        this.summary = summary;
    }
}

export function Setting$2$reflection(gen0, gen1) {
    return record_type("DerivedTraits.Setting`2", [gen0, gen1], Setting$2, () => [["instance", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [gen0, class_type("Microsoft.FSharp.Collections.FSharpMap`2", [int32_type, array_type(int32_type)])])], ["summary", gen1]]);
}

export function op_EqualsEqualsGreater(trait0, options) {
    return [trait0, fresh(options)];
}

export function confer(trait0, options) {
    let inputRecord;
    return [trait0, (inputRecord = fresh(options), new Choice$2(inputRecord.options, inputRecord.preconditions, length(options), inputRecord.mustBeDistinct, inputRecord.elideFromDisplayAndSummary, true))];
}

export function invisiblyConfer(trait0, options) {
    let inputRecord;
    return [trait0, (inputRecord = fresh(options), new Choice$2(inputRecord.options, inputRecord.preconditions, length(options), inputRecord.mustBeDistinct, true, true))];
}

export function rulesOf(rules) {
    let table_2;
    let derivationRules = empty();
    const enumerator = getEnumerator(rules);
    try {
        while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
            const forLoopVar = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
            const key = forLoopVar[0];
            const choice = forLoopVar[1];
            const matchValue = tryFind(key, derivationRules);
            if (matchValue != null) {
                const choices = matchValue;
                derivationRules = ((table_2 = derivationRules, add(key, append(choices, [choice]), table_2)));
            }
            else {
                derivationRules = add(key, [choice], derivationRules);
            }
        }
    }
    finally {
        enumerator.Dispose();
    }
    return derivationRules;
}

export function collect(rules, roots, ctx, instance) {
    const seekFixedPoint = (filterArgs_mut, priorPoint_mut) => {
        seekFixedPoint:
        while (true) {
            const filterArgs = filterArgs_mut, priorPoint = priorPoint_mut;
            const recur = (roots_1) => toList(delay(() => collect_1((root) => {
                const activePatternResult13208 = $007CLookup$007C_$007C(root, rules);
                if (activePatternResult13208 != null) {
                    const choices = activePatternResult13208;
                    return collect_1((matchValue) => {
                        const ix = matchValue[0] | 0;
                        const choice = matchValue[1];
                        let isValid;
                        const matchValue_1 = choice.preconditions;
                        if (matchValue_1 != null) {
                            const filter = matchValue_1;
                            isValid = ((trait1) => filter([trait1, filterArgs]));
                        }
                        else {
                            isValid = ((arg10$0040) => thunk(true, arg10$0040));
                        }
                        let chosenOptions;
                        if (choice.autopick) {
                            chosenOptions = choice.options.filter(isValid);
                        }
                        else {
                            let pattern_matching_result;
                            const activePatternResult13202 = $007CLookup$007C_$007C(root, instance);
                            if (activePatternResult13202 != null) {
                                const activePatternResult13204 = $007CLookup$007C_$007C(ix, activePatternResult13202);
                                if (activePatternResult13204 != null) {
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
                                    const deref = (i) => choice.options[i];
                                    chosenOptions = map(deref, FSharpMap__get_Item(FSharpMap__get_Item(instance, root), ix)).filter(isValid);
                                    break;
                                }
                                case 1: {
                                    chosenOptions = (new Array(0));
                                    break;
                                }
                            }
                        }
                        return append_1(chosenOptions, delay(() => recur(chosenOptions)));
                    }, mapIndexed((x, y) => tuple2(x, y), choices));
                }
                else {
                    return empty_1();
                }
            }, roots_1)));
            const retval = recur(roots);
            if (equals(retval, priorPoint)) {
                return retval;
            }
            else {
                filterArgs_mut = [ofSeq(retval, {
                    Compare: (x_1, y_1) => compare(x_1, y_1),
                }), ctx];
                priorPoint_mut = retval;
                continue seekFixedPoint;
            }
            break;
        }
    };
    return seekFixedPoint([empty_2({
        Compare: (x_2, y_2) => compare(x_2, y_2),
    }), ctx], void 0);
}

export function summarize(f, rules, roots, ctx, instance) {
    const currentTraits = collect(rules, roots, ctx, instance);
    const filterArgs = [ofSeq(currentTraits, {
        Compare: (x, y) => compare(x, y),
    }), ctx];
    const recur = (roots_1) => toList(delay(() => collect_1((root) => {
        const activePatternResult13228 = $007CLookup$007C_$007C(root, rules);
        if (activePatternResult13228 != null) {
            const choices = activePatternResult13228;
            return collect_1((matchValue) => {
                let matchValue_2, v_1;
                const ix = matchValue[0] | 0;
                const choice = matchValue[1];
                let isValid;
                const matchValue_1 = choice.preconditions;
                if (matchValue_1 != null) {
                    const filter = matchValue_1;
                    isValid = ((trait1) => filter([trait1, filterArgs]));
                }
                else {
                    isValid = ((arg10$0040) => thunk(true, arg10$0040));
                }
                let chosenOptions;
                if (choice.autopick) {
                    chosenOptions = choice.options.filter(isValid);
                }
                else {
                    let pattern_matching_result;
                    const activePatternResult13222 = $007CLookup$007C_$007C(root, instance);
                    if (activePatternResult13222 != null) {
                        const activePatternResult13224 = $007CLookup$007C_$007C(ix, activePatternResult13222);
                        if (activePatternResult13224 != null) {
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
                            const pick = (i) => choice.options[i];
                            chosenOptions = map(pick, FSharpMap__get_Item(FSharpMap__get_Item(instance, root), ix)).filter(isValid);
                            break;
                        }
                        case 1: {
                            chosenOptions = (new Array(0));
                            break;
                        }
                    }
                }
                return append_1((choice.elideFromDisplayAndSummary === false) ? ((matchValue_2 = f([root, ix, choice, chosenOptions]), (matchValue_2 == null) ? ((empty_1())) : ((v_1 = value_2(matchValue_2), singleton(v_1))))) : empty_1(), delay(() => recur(chosenOptions)));
            }, mapIndexed((x_1, y_1) => tuple2(x_1, y_1), choices));
        }
        else {
            return empty_1();
        }
    }, roots_1)));
    return recur(roots);
}

export function summarizeAll(f, rules, roots, ctx, instance) {
    const currentTraits = collect(rules, roots, ctx, instance);
    const filterArgs = [ofSeq(currentTraits, {
        Compare: (x, y) => compare(x, y),
    }), ctx];
    const recur = (roots_1) => toList(delay(() => collect_1((root) => {
        const activePatternResult13247 = $007CLookup$007C_$007C(root, rules);
        if (activePatternResult13247 != null) {
            const choices = activePatternResult13247;
            return collect_1((matchValue) => {
                let matchValue_2, v_1;
                const ix = matchValue[0] | 0;
                const choice = matchValue[1];
                let isValid;
                const matchValue_1 = choice.preconditions;
                if (matchValue_1 != null) {
                    const filter = matchValue_1;
                    isValid = ((trait1) => filter([trait1, filterArgs]));
                }
                else {
                    isValid = ((arg10$0040) => thunk(true, arg10$0040));
                }
                let chosenOptions;
                if (choice.autopick) {
                    chosenOptions = choice.options.filter(isValid);
                }
                else {
                    let pattern_matching_result;
                    const activePatternResult13241 = $007CLookup$007C_$007C(root, instance);
                    if (activePatternResult13241 != null) {
                        const activePatternResult13243 = $007CLookup$007C_$007C(ix, activePatternResult13241);
                        if (activePatternResult13243 != null) {
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
                            const pick = (i) => choice.options[i];
                            chosenOptions = map(pick, FSharpMap__get_Item(FSharpMap__get_Item(instance, root), ix)).filter(isValid);
                            break;
                        }
                        case 1: {
                            chosenOptions = (new Array(0));
                            break;
                        }
                    }
                }
                return append_1((matchValue_2 = f([root, ix, choice, chosenOptions]), (matchValue_2 == null) ? ((empty_1())) : ((v_1 = value_2(matchValue_2), singleton(v_1)))), delay(() => recur(chosenOptions)));
            }, mapIndexed((x_1, y_1) => tuple2(x_1, y_1), choices));
        }
        else {
            return empty_1();
        }
    }, roots_1)));
    return recur(roots);
}

export function describeChoiceAsText(toText, head, ix, choice, decision) {
    if (choice.numberAllowed === decision.length) {
        return `${map(toText, decision)}`;
    }
    else {
        return `${head} ==> [${join("; ", map(toText, decision))}]`;
    }
}

export function toSetting(summarize$0027, rules, roots, ctx, instance) {
    const traits = collect(rules, roots, ctx, instance);
    return new Setting$2(instance, summarize$0027(traits));
}

export function toggleTrait(rules, head, choiceIx, decisionIx, instance) {
    let activePatternResult13268, rules_1;
    const rule = (activePatternResult13268 = $007CLookup$007C_$007C(head, rules), (activePatternResult13268 != null) ? ((rules_1 = activePatternResult13268, rules_1[choiceIx])) : shouldntHappen());
    return change_1(head, (_arg1) => {
        if (_arg1 != null) {
            const decisions = _arg1;
            const change = (_arg2) => {
                let ixs_1;
                if (_arg2 == null) {
                    return new Int32Array([decisionIx]);
                }
                else {
                    const ixs = _arg2;
                    let d;
                    if (contains(decisionIx, ixs, {
                        Equals: (x, y) => (x === y),
                        GetHashCode: (x) => numberHash(x),
                    })) {
                        d = ixs.filter((y_1) => (decisionIx !== y_1));
                    }
                    else {
                        const matchValue = append(new Int32Array([decisionIx]), ixs, Int32Array);
                        if ((ixs_1 = matchValue, rule.mustBeDistinct)) {
                            const ixs_2 = matchValue;
                            d = Array_distinct(ixs_2, {
                                Equals: (x_1, y_2) => (x_1 === y_2),
                                GetHashCode: (x_1) => numberHash(x_1),
                            });
                        }
                        else {
                            const ixs_3 = matchValue;
                            d = ixs_3;
                        }
                    }
                    return (rule.numberAllowed >= d.length) ? d : take(rule.numberAllowed, d, Int32Array);
                }
            };
            return change_1(choiceIx, change, decisions);
        }
        else {
            return ofList(singleton_1([choiceIx, new Int32Array([decisionIx])]));
        }
    }, instance);
}

export function $007CHasTrait$007C(rules, head, trait$0027, instance) {
    const activePatternResult13286 = $007CLookup$007C_$007C(head, rules);
    if (activePatternResult13286 != null) {
        const choices = activePatternResult13286;
        const hasTraitSelected = (tupledArg) => {
            const ix = tupledArg[0] | 0;
            const choice = tupledArg[1];
            let pattern_matching_result, decisionIxs;
            const activePatternResult13280 = $007CLookup$007C_$007C(head, instance);
            if (activePatternResult13280 != null) {
                const activePatternResult13282 = $007CLookup$007C_$007C(ix, activePatternResult13280);
                if (activePatternResult13282 != null) {
                    pattern_matching_result = 0;
                    decisionIxs = activePatternResult13282;
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
                    return decisionIxs.some((ix_1) => {
                        if (ix_1 < choice.options.length) {
                            return equals(choice.options[ix_1], trait$0027);
                        }
                        else {
                            return false;
                        }
                    });
                }
                case 1: {
                    return false;
                }
            }
        };
        return mapIndexed((x, y) => tuple2(x, y), choices).some(hasTraitSelected);
    }
    else {
        return false;
    }
}

//# sourceMappingURL=DerivedTraits.fs.js.map
