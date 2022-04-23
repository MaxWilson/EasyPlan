import { toString as toString_1, Union, Record } from "../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { string_type, class_type, union_type, record_type, bool_type, int32_type, list_type } from "../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { head as head_2, tail, isEmpty, contains, mapIndexed, empty as empty_1, item, cons, map as map_1, singleton as singleton_1, ofArray, length } from "../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { empty as empty_2, collect, singleton, append, delay, toList } from "../ShiningSword/fable_modules/fable-library.3.6.2/Seq.js";
import { change, ofList, FSharpMap__get_Item, add, tryFind, empty } from "../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { structuralHash, equals, getEnumerator } from "../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { value as value_2 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";
import { String_join, tuple2 } from "./Common.fs.js";
import { printf, toConsole, join } from "../ShiningSword/fable_modules/fable-library.3.6.2/String.js";
import { rangeDouble } from "../ShiningSword/fable_modules/fable-library.3.6.2/Range.js";

export class Choice$1 extends Record {
    constructor(options, numberAllowed, mustBeDistinct, elideFromDisplayAndSummary, autopick) {
        super();
        this.options = options;
        this.numberAllowed = (numberAllowed | 0);
        this.mustBeDistinct = mustBeDistinct;
        this.elideFromDisplayAndSummary = elideFromDisplayAndSummary;
        this.autopick = autopick;
    }
}

export function Choice$1$reflection(gen0) {
    return record_type("AutoWizard.Choice`1", [gen0], Choice$1, () => [["options", list_type(gen0)], ["numberAllowed", int32_type], ["mustBeDistinct", bool_type], ["elideFromDisplayAndSummary", bool_type], ["autopick", bool_type]]);
}

export function fresh(options) {
    return new Choice$1(options, 1, false, false, false);
}

export class DerivationRule$1 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Rule"];
    }
}

export function DerivationRule$1$reflection(gen0) {
    return union_type("AutoWizard.DerivationRule`1", [gen0], DerivationRule$1, () => [[["key", gen0], ["choice", Choice$1$reflection(gen0)]]]);
}

export class Setting$1 extends Record {
    constructor(instance, summary) {
        super();
        this.instance = instance;
        this.summary = summary;
    }
}

export function Setting$1$reflection(gen0) {
    return record_type("AutoWizard.Setting`1", [gen0], Setting$1, () => [["instance", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [gen0, class_type("Microsoft.FSharp.Collections.FSharpMap`2", [int32_type, list_type(int32_type)])])], ["summary", list_type(gen0)]]);
}

export function op_EqualsEqualsGreater(trait0, options) {
    return [trait0, fresh(options)];
}

export function confer(trait0, options) {
    let inputRecord;
    return [trait0, (inputRecord = fresh(options), new Choice$1(inputRecord.options, length(options), inputRecord.mustBeDistinct, inputRecord.elideFromDisplayAndSummary, true))];
}

export class Sample_Stat extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Str", "Dex", "Con", "Int", "Wis", "Cha"];
    }
}

export function Sample_Stat$reflection() {
    return union_type("AutoWizard.Sample.Stat", [], Sample_Stat, () => [[], [], [], [], [], []]);
}

export class Sample_Traits extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["PC", "Race", "Elf", "WoodElf", "HighElf", "DrowElf", "Human", "ASI", "Feat", "GWM", "Tough", "Lucky", "Mobile", "HeavyArmorMaster", "WizardCantrip", "Cantrip", "MaskOfTheWild", "Faster", "SunlightSensitivity", "ImprovedDarkvision", "SwordBowBonus"];
    }
}

export function Sample_Traits$reflection() {
    return union_type("AutoWizard.Sample.Traits", [], Sample_Traits, () => [[], [], [], [], [], [], [], [["Item1", Sample_Stat$reflection()], ["Item2", int32_type]], [], [], [], [], [], [], [], [["Item", string_type]], [], [["Item", int32_type]], [], [], [["Item", int32_type]]]);
}

export const Sample_feats = ofArray([new Sample_Traits(9), new Sample_Traits(10), new Sample_Traits(11), new Sample_Traits(12), new Sample_Traits(13)]);

export const Sample_rules = toList(delay(() => {
    let inputRecord;
    return append(singleton([new Sample_Traits(0), (inputRecord = fresh(singleton_1(new Sample_Traits(1))), new Choice$1(inputRecord.options, inputRecord.numberAllowed, inputRecord.mustBeDistinct, true, true))]), delay(() => append(singleton(op_EqualsEqualsGreater(new Sample_Traits(1), ofArray([new Sample_Traits(2), new Sample_Traits(6)]))), delay(() => {
        let inputRecord_1;
        const stats = ofArray([new Sample_Stat(0), new Sample_Stat(1), new Sample_Stat(2), new Sample_Stat(3), new Sample_Stat(4), new Sample_Stat(5)]);
        return append(singleton([new Sample_Traits(6), (inputRecord_1 = fresh(map_1((x) => (new Sample_Traits(7, x, 1)), stats)), new Choice$1(inputRecord_1.options, 2, true, inputRecord_1.elideFromDisplayAndSummary, inputRecord_1.autopick))]), delay(() => append(singleton(confer(new Sample_Traits(6), singleton_1(new Sample_Traits(8)))), delay(() => append(singleton(op_EqualsEqualsGreater(new Sample_Traits(8), Sample_feats)), delay(() => append(singleton(confer(new Sample_Traits(2), singleton_1(new Sample_Traits(20, 1)))), delay(() => append(singleton(op_EqualsEqualsGreater(new Sample_Traits(2), ofArray([new Sample_Traits(4), new Sample_Traits(3), new Sample_Traits(5)]))), delay(() => append(singleton(confer(new Sample_Traits(3), ofArray([new Sample_Traits(16), new Sample_Traits(17, 5)]))), delay(() => singleton(confer(new Sample_Traits(5), ofArray([new Sample_Traits(19), new Sample_Traits(18)])))))))))))))));
    }))));
}));

export function rulesOf(rules_1) {
    let derivationRules = empty();
    const enumerator = getEnumerator(rules_1);
    try {
        while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
            const forLoopVar = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
            const key = forLoopVar[0];
            const choice = forLoopVar[1];
            const matchValue = tryFind(key, derivationRules);
            if (matchValue != null) {
                const choices = matchValue;
                derivationRules = add(key, cons(choice, choices), derivationRules);
            }
            else {
                derivationRules = add(key, singleton_1(choice), derivationRules);
            }
        }
    }
    finally {
        enumerator.Dispose();
    }
    return derivationRules;
}

export function $007CLookup$007C_$007C(key, map) {
    return tryFind(key, map);
}

export function summarize(f, rules_1, instance_1, roots) {
    const recur = (roots_1) => toList(delay(() => collect((root) => {
        const activePatternResult126014 = $007CLookup$007C_$007C(root, rules_1);
        if (activePatternResult126014 != null) {
            const choices = activePatternResult126014;
            return collect((matchValue) => {
                let matchValue_1, v;
                const ix = matchValue[0] | 0;
                const choice = matchValue[1];
                let chosenOptions;
                if (choice.autopick) {
                    chosenOptions = choice.options;
                }
                else {
                    let pattern_matching_result;
                    const activePatternResult126008 = $007CLookup$007C_$007C(root, instance_1);
                    if (activePatternResult126008 != null) {
                        const activePatternResult126010 = $007CLookup$007C_$007C(ix, activePatternResult126008);
                        if (activePatternResult126010 != null) {
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
                            const pick = (i) => item(i, choice.options);
                            chosenOptions = map_1(pick, FSharpMap__get_Item(FSharpMap__get_Item(instance_1, root), ix));
                            break;
                        }
                        case 1: {
                            chosenOptions = empty_1();
                            break;
                        }
                    }
                }
                return append((choice.elideFromDisplayAndSummary === false) ? ((matchValue_1 = f([root, ix, choice, chosenOptions]), (matchValue_1 == null) ? ((empty_2())) : ((v = value_2(matchValue_1), singleton(v))))) : empty_2(), delay(() => recur(chosenOptions)));
            }, mapIndexed((x, y) => tuple2(x, y), choices));
        }
        else {
            return empty_2();
        }
    }, roots_1)));
    return recur(roots);
}

export const rules = rulesOf(Sample_rules);

export function describeChoice(head, ix, choice, decision) {
    const toString = (x) => {
        let copyOfStruct = x;
        return toString_1(copyOfStruct);
    };
    if (length(choice.options) === length(decision)) {
        return `${decision}`;
    }
    else {
        return `${head} can be ${join(", ", map_1(toString, choice.options))}. Current: ${decision}`;
    }
}

export function choose(rules_1, roots, head, value, instance_1) {
    const render = (tupledArg) => {
        const head$0027 = tupledArg[0];
        const ix = tupledArg[1];
        const choice = tupledArg[2];
        if (equals(head, head$0027) && contains(value, choice.options, {
            Equals: (x, y) => equals(x, y),
            GetHashCode: (x) => structuralHash(x),
        })) {
            return [head, ix, choice];
        }
        else {
            return void 0;
        }
    };
    const matchValue = summarize(render, rules_1, instance_1, roots);
    let pattern_matching_result, choice_1, head_1, ix_1;
    if (!isEmpty(matchValue)) {
        if (isEmpty(tail(matchValue))) {
            pattern_matching_result = 0;
            choice_1 = head_2(matchValue)[2];
            head_1 = head_2(matchValue)[0];
            ix_1 = head_2(matchValue)[1];
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
            const choiceIx = toList(delay(() => collect((i) => (equals(item(i, choice_1.options), value) ? singleton(i) : empty_2()), rangeDouble(0, 1, length(choice_1.options) - 1))));
            const assign = (_arg2) => {
                if (_arg2 != null) {
                    const existing = _arg2;
                    return add(ix_1, choiceIx, existing);
                }
                else {
                    return ofList(singleton_1([ix_1, choiceIx]));
                }
            };
            return change(head_1, assign, instance_1);
        }
        case 1: {
            return instance_1;
        }
    }
}

export const choose$0027 = (head) => ((value) => ((instance_1) => choose(rules, singleton_1(new Sample_Traits(0)), head, value, instance_1)));

export const instance = choose$0027(new Sample_Traits(8))(new Sample_Traits(9))(choose$0027(new Sample_Traits(1))(new Sample_Traits(6))(empty()));

export const p = (() => {
    const arg10 = String_join("\n", summarize((tupledArg) => describeChoice(tupledArg[0], tupledArg[1], tupledArg[2], tupledArg[3]), rules, instance, singleton_1(new Sample_Traits(0))));
    toConsole(printf("%s"))(arg10);
})();

//# sourceMappingURL=AutoWizard.fs.js.map
