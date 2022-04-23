import { toString, Record, Union } from "../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { class_type, tuple_type, array_type, option_type, record_type, int32_type, string_type, union_type } from "../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { singleton, map, head as head_3, tail, isEmpty, cons, empty, initialize, sum as sum_2, ofArray } from "../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { safeHash, equals, max, comparePrimitives, int32ToString } from "../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { chooseRandomExponentialDecay, chooseRandom, List_every, rand, thunk1 } from "./Common.fs.js";
import { op_UnaryNegation_Int32 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Int32.js";
import { contains, FSharpSet__Contains, ofSeq } from "../ShiningSword/fable_modules/fable-library.3.6.2/Set.js";
import { singleton as singleton_1, append, delay, choose, max as max_1, map as map_1, sum as sum_3, exists, toList } from "../ShiningSword/fable_modules/fable-library.3.6.2/Seq.js";
import { rangeChar } from "../ShiningSword/fable_modules/fable-library.3.6.2/Range.js";
import { isLetterOrDigit } from "../ShiningSword/fable_modules/fable-library.3.6.2/Char.js";
import { invisiblyConfer, confer, fresh, op_EqualsEqualsGreater, rulesOf, Choice$2, Setting$2$reflection } from "./DerivedTraits.fs.js";
import { tryFind, FSharpMap__get_Item, containsKey } from "../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { interpolate, toText } from "../ShiningSword/fable_modules/fable-library.3.6.2/String.js";
import { groupBy } from "../ShiningSword/fable_modules/fable-library.3.6.2/Seq2.js";
import { some } from "../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";
import { nameLists } from "./Onomastikon.fs.js";

export class Stat extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Str", "Dex", "Con", "Int", "Wis", "Cha"];
    }
}

export function Stat$reflection() {
    return union_type("Domain.Character.Stat", [], Stat, () => [[], [], [], [], [], []]);
}

export function Stat_get_All() {
    return ofArray([new Stat(0), new Stat(1), new Stat(2), new Stat(3), new Stat(4), new Stat(5)]);
}

export class Sex extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Male", "Female", "Neither"];
    }
}

export function Sex$reflection() {
    return union_type("Domain.Character.Sex", [], Sex, () => [[], [], []]);
}

export class Origin extends Record {
    constructor(ruleSystem, nationalOrigin, startingLevel, statRollMethod) {
        super();
        this.ruleSystem = ruleSystem;
        this.nationalOrigin = nationalOrigin;
        this.startingLevel = (startingLevel | 0);
        this.statRollMethod = statRollMethod;
    }
}

export function Origin$reflection() {
    return record_type("Domain.Character.Origin", [], Origin, () => [["ruleSystem", string_type], ["nationalOrigin", string_type], ["startingLevel", int32_type], ["statRollMethod", string_type]]);
}

export class RollSpec extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["StaticBonus", "RollSpec"];
    }
    toString() {
        const this$ = this;
        const loop = (needsOperator, _arg2) => {
            if (_arg2.tag === 1) {
                const rest = _arg2.fields[2];
                const n_1 = _arg2.fields[0] | 0;
                const d = _arg2.fields[1] | 0;
                const prefix = (needsOperator && (n_1 >= 0)) ? (`+${n_1}d${d}`) : (`${n_1}d${d}`);
                let pattern_matching_result, rest_1;
                if (rest != null) {
                    if (rest.tag === 0) {
                        if (rest.fields[0] === 0) {
                            pattern_matching_result = 0;
                        }
                        else {
                            pattern_matching_result = 1;
                            rest_1 = rest;
                        }
                    }
                    else {
                        pattern_matching_result = 1;
                        rest_1 = rest;
                    }
                }
                else {
                    pattern_matching_result = 0;
                }
                switch (pattern_matching_result) {
                    case 0: {
                        return prefix;
                    }
                    case 1: {
                        return `${prefix}${loop(true, rest_1)}`;
                    }
                }
            }
            else {
                const n = _arg2.fields[0] | 0;
                if (needsOperator && (n >= 0)) {
                    return `+${n}`;
                }
                else {
                    return int32ToString(n);
                }
            }
        };
        return loop(false, this$);
    }
}

export function RollSpec$reflection() {
    return union_type("Domain.Character.RollSpec", [], RollSpec, () => [[["Item", int32_type]], [["n", int32_type], ["d", int32_type], ["rest", option_type(RollSpec$reflection())]]]);
}

export function RollSpec__roll(this$) {
    const loop = (_arg1) => {
        if (_arg1.tag === 1) {
            const rest = _arg1.fields[2];
            const n_1 = _arg1.fields[0] | 0;
            const d = _arg1.fields[1] | 0;
            const sum = sum_2(initialize(Math.abs(n_1), (arg20$0040) => thunk1((x) => rand(x), d, arg20$0040)), {
                GetZero: () => 0,
                Add: (x_1, y) => (x_1 + y),
            }) | 0;
            const sum_1 = ((n_1 < 0) ? op_UnaryNegation_Int32(sum) : sum) | 0;
            if (rest == null) {
                return sum_1 | 0;
            }
            else {
                const rest_1 = rest;
                return (sum_1 + loop(rest_1)) | 0;
            }
        }
        else {
            const n = _arg1.fields[0] | 0;
            return n | 0;
        }
    };
    return loop(this$) | 0;
}

export function RollSpec_create_Z524259A4(bonus) {
    return new RollSpec(0, bonus);
}

export function RollSpec_create_Z37302880(n, d) {
    return new RollSpec(1, n, d, void 0);
}

export function RollSpec_create_4F7761DC(n, d, bonus) {
    if (bonus !== 0) {
        return new RollSpec(1, n, d, new RollSpec(0, bonus));
    }
    else {
        return new RollSpec(1, n, d, void 0);
    }
}

export function RollSpec_create_3355C924(n, d, rest) {
    return new RollSpec(1, n, d, rest);
}

export function RollSpec_op_Addition_Z57C2BA88(lhs, rhs) {
    const addBonus = (bonus, _arg3) => {
        if (_arg3.tag === 1) {
            if (_arg3.fields[2] != null) {
                const d_1 = _arg3.fields[1] | 0;
                const n_2 = _arg3.fields[0] | 0;
                const rest = _arg3.fields[2];
                return new RollSpec(1, n_2, d_1, addBonus(bonus, rest));
            }
            else {
                const d = _arg3.fields[1] | 0;
                const n_1 = _arg3.fields[0] | 0;
                return new RollSpec(1, n_1, d, new RollSpec(0, bonus));
            }
        }
        else {
            const n = _arg3.fields[0] | 0;
            return new RollSpec(0, n + bonus);
        }
    };
    return addBonus(rhs, lhs);
}

export function RollSpec_op_Addition_Z2BE01280(lhs, rhs) {
    const addRhs = (_arg4) => {
        if (_arg4.tag === 1) {
            if (_arg4.fields[2] != null) {
                const d_1 = _arg4.fields[1] | 0;
                const n_2 = _arg4.fields[0] | 0;
                const rest = _arg4.fields[2];
                return new RollSpec(1, n_2, d_1, addRhs(rest));
            }
            else {
                const d = _arg4.fields[1] | 0;
                const n_1 = _arg4.fields[0] | 0;
                return new RollSpec(1, n_1, d, rhs);
            }
        }
        else {
            const n = _arg4.fields[0] | 0;
            return RollSpec_op_Addition_Z57C2BA88(rhs, n);
        }
    };
    return addRhs(lhs);
}

export function RollSpec_op_Subtraction_Z37302880(lhs, rhs) {
    return lhs + op_UnaryNegation_Int32(rhs);
}

export function RollSpec_op_Subtraction_Z2BE01280(lhs, rhs) {
    const invert = (_arg5) => {
        if (_arg5.tag === 1) {
            if (_arg5.fields[2] != null) {
                const d_1 = _arg5.fields[1] | 0;
                const n_2 = _arg5.fields[0] | 0;
                const rest = _arg5.fields[2];
                return new RollSpec(1, op_UnaryNegation_Int32(n_2), d_1, invert(rest));
            }
            else {
                const d = _arg5.fields[1] | 0;
                const n_1 = _arg5.fields[0] | 0;
                return new RollSpec(1, op_UnaryNegation_Int32(n_1), d, void 0);
            }
        }
        else {
            const n = _arg5.fields[0] | 0;
            return new RollSpec(0, op_UnaryNegation_Int32(n));
        }
    };
    return RollSpec_op_Addition_Z2BE01280(lhs, invert(rhs));
}

export function uncamel(str) {
    let letter, letter_2;
    const caps = ofSeq(toList(rangeChar("A", "Z")), {
        Compare: (x, y) => comparePrimitives(x, y),
    });
    const lower = ofSeq(toList(rangeChar("a", "z")), {
        Compare: (x_1, y_1) => comparePrimitives(x_1, y_1),
    });
    let spaceNeededBefore = empty();
    let inWord = true;
    for (let i = 1; i <= (str.length - 1); i++) {
        const matchValue = str[i];
        if (matchValue === " ") {
            inWord = false;
        }
        else if ((letter = matchValue, (FSharpSet__Contains(caps, letter) && inWord) && ((!FSharpSet__Contains(caps, str[i - 1])) ? true : (((i + 1) < str.length) && FSharpSet__Contains(lower, str[i + 1]))))) {
            const letter_1 = matchValue;
            spaceNeededBefore = cons(i, spaceNeededBefore);
        }
        else if ((letter_2 = matchValue, isLetterOrDigit(letter_2))) {
            const letter_3 = matchValue;
            inWord = true;
        }
    }
    const recur = (workingCopy_mut, spacesNeeded_mut) => {
        recur:
        while (true) {
            const workingCopy = workingCopy_mut, spacesNeeded = spacesNeeded_mut;
            if (!isEmpty(spacesNeeded)) {
                const rest = tail(spacesNeeded);
                const index = head_3(spacesNeeded) | 0;
                workingCopy_mut = (`${workingCopy.slice(0, (index - 1) + 1)} ${workingCopy.slice(index, workingCopy.length)}`);
                spacesNeeded_mut = rest;
                continue recur;
            }
            else {
                return workingCopy;
            }
            break;
        }
    };
    return recur(str, spaceNeededBefore);
}

export class ADND2nd_WorshipFocus extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Oghma", "Lugh", "Osiris", "Isis", "Odin", "Thor", "Idun"];
    }
}

export function ADND2nd_WorshipFocus$reflection() {
    return union_type("Domain.Character.ADND2nd.WorshipFocus", [], ADND2nd_WorshipFocus, () => [[], [], [], [], [], [], []]);
}

export function ADND2nd_WorshipFocus_get_All() {
    return ofArray([new ADND2nd_WorshipFocus(0), new ADND2nd_WorshipFocus(1), new ADND2nd_WorshipFocus(2), new ADND2nd_WorshipFocus(3), new ADND2nd_WorshipFocus(4), new ADND2nd_WorshipFocus(5), new ADND2nd_WorshipFocus(6)]);
}

export class ADND2nd_PsionicDiscipline extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Clairsentience", "Psychokinesis", "Psychometabolism", "Psychoportation", "Telepathy", "Metapsionics"];
    }
}

export function ADND2nd_PsionicDiscipline$reflection() {
    return union_type("Domain.Character.ADND2nd.PsionicDiscipline", [], ADND2nd_PsionicDiscipline, () => [[], [], [], [], [], []]);
}

export function ADND2nd_PsionicDiscipline_get_All() {
    return ofArray([new ADND2nd_PsionicDiscipline(0), new ADND2nd_PsionicDiscipline(1), new ADND2nd_PsionicDiscipline(2), new ADND2nd_PsionicDiscipline(3), new ADND2nd_PsionicDiscipline(4), new ADND2nd_PsionicDiscipline(5)]);
}

export class ADND2nd_CharacterClass extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Fighter", "Ranger", "Paladin", "Wizard", "Cleric", "Druid", "Priest", "Thief", "Bard", "Psionicist"];
    }
}

export function ADND2nd_CharacterClass$reflection() {
    return union_type("Domain.Character.ADND2nd.CharacterClass", [], ADND2nd_CharacterClass, () => [[], [], [], [], [], [], [], [], [], []]);
}

export class ADND2nd_Race extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Human", "Elf", "Dwarf", "HalfElf", "Halfling", "HalfGiant", "ThriKreen"];
    }
}

export function ADND2nd_Race$reflection() {
    return union_type("Domain.Character.ADND2nd.Race", [], ADND2nd_Race, () => [[], [], [], [], [], [], []]);
}

export class ADND2nd_Trait extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["PC", "StatMod", "RaceOf", "SingleClass", "SwordBowBonus", "HDMultiplier", "Level", "Worship", "PrimaryDiscipline", "LimitedRegeneration", "WeaponSpecialist"];
    }
}

export function ADND2nd_Trait$reflection() {
    return union_type("Domain.Character.ADND2nd.Trait", [], ADND2nd_Trait, () => [[], [["Item1", Stat$reflection()], ["Item2", int32_type]], [["Item", ADND2nd_Race$reflection()]], [], [["Item", int32_type]], [["Item", int32_type]], [["Item1", ADND2nd_CharacterClass$reflection()], ["level", int32_type]], [["Item", ADND2nd_WorshipFocus$reflection()]], [["Item", ADND2nd_PsionicDiscipline$reflection()]], [["minutes", int32_type]], []]);
}

export class ADND2nd_CharacterSheet extends Record {
    constructor(id, name, origin, sex, Str, Dex, Con, Int, Wis, Cha, exceptionalStrength, originalRolls, hp, ac, attacks, toHitBonus, damage, xp, levels, traits, wealth) {
        super();
        this.id = id;
        this.name = name;
        this.origin = origin;
        this.sex = sex;
        this.Str = (Str | 0);
        this.Dex = (Dex | 0);
        this.Con = (Con | 0);
        this.Int = (Int | 0);
        this.Wis = (Wis | 0);
        this.Cha = (Cha | 0);
        this.exceptionalStrength = exceptionalStrength;
        this.originalRolls = originalRolls;
        this.hp = hp;
        this.ac = (ac | 0);
        this.attacks = (attacks | 0);
        this.toHitBonus = (toHitBonus | 0);
        this.damage = damage;
        this.xp = (xp | 0);
        this.levels = levels;
        this.traits = traits;
        this.wealth = (wealth | 0);
    }
}

export function ADND2nd_CharacterSheet$reflection() {
    return record_type("Domain.Character.ADND2nd.CharacterSheet", [], ADND2nd_CharacterSheet, () => [["id", option_type(int32_type)], ["name", string_type], ["origin", Origin$reflection()], ["sex", Sex$reflection()], ["Str", int32_type], ["Dex", int32_type], ["Con", int32_type], ["Int", int32_type], ["Wis", int32_type], ["Cha", int32_type], ["exceptionalStrength", option_type(int32_type)], ["originalRolls", array_type(int32_type)], ["hp", array_type(tuple_type(int32_type, int32_type))], ["ac", int32_type], ["attacks", int32_type], ["toHitBonus", int32_type], ["damage", RollSpec$reflection()], ["xp", int32_type], ["levels", array_type(tuple_type(ADND2nd_CharacterClass$reflection(), int32_type))], ["traits", Setting$2$reflection(ADND2nd_Trait$reflection(), class_type("Microsoft.FSharp.Collections.FSharpSet`1", [ADND2nd_Trait$reflection()]))], ["wealth", int32_type]]);
}

export class ADND2nd_PreconditionContext extends Record {
    constructor(preracialStats, postracialStats) {
        super();
        this.preracialStats = preracialStats;
        this.postracialStats = postracialStats;
    }
}

export function ADND2nd_PreconditionContext$reflection() {
    return record_type("Domain.Character.ADND2nd.PreconditionContext", [], ADND2nd_PreconditionContext, () => [["preracialStats", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [Stat$reflection(), int32_type])], ["postracialStats", class_type("Microsoft.FSharp.Collections.FSharpMap`2", [Stat$reflection(), int32_type])]]);
}

export function ADND2nd_precondition(pattern, head, options) {
    return [head, new Choice$2(options.options, (tupledArg) => {
        const trait1 = tupledArg[0];
        const ctx = tupledArg[1];
        return pattern([trait1, ctx]);
    }, options.numberAllowed, options.mustBeDistinct, options.elideFromDisplayAndSummary, options.autopick)];
}

export function ADND2nd_preracialStatMin(prereqs, traits, ctx) {
    return List_every((tupledArg) => {
        const stat = tupledArg[0];
        const minimum = tupledArg[1] | 0;
        return containsKey(stat, ctx.preracialStats) && (FSharpMap__get_Item(ctx.preracialStats, stat) >= minimum);
    })(prereqs);
}

export function ADND2nd_preracialStatRange(prereqs, traits, ctx) {
    return List_every((tupledArg) => {
        const stat = tupledArg[0];
        const minimum = tupledArg[1] | 0;
        const maximum = tupledArg[2] | 0;
        return (containsKey(stat, ctx.preracialStats) && (minimum <= FSharpMap__get_Item(ctx.preracialStats, stat))) && (FSharpMap__get_Item(ctx.preracialStats, stat) <= maximum);
    })(prereqs);
}

export function ADND2nd_statMin(prereqs, traits, ctx) {
    return List_every((tupledArg) => {
        const stat = tupledArg[0];
        const minimum = tupledArg[1] | 0;
        return containsKey(stat, ctx.postracialStats) && (FSharpMap__get_Item(ctx.postracialStats, stat) >= minimum);
    })(prereqs);
}

export function ADND2nd_statRange(prereqs, traits, ctx) {
    return List_every((tupledArg) => {
        const stat = tupledArg[0];
        const minimum = tupledArg[1] | 0;
        const maximum = tupledArg[2] | 0;
        return (containsKey(stat, ctx.postracialStats) && (minimum <= FSharpMap__get_Item(ctx.postracialStats, stat))) && (FSharpMap__get_Item(ctx.postracialStats, stat) <= maximum);
    })(prereqs);
}

export function ADND2nd_hasTrait(trait1, traits, ctx) {
    return contains(trait1, traits);
}

export function ADND2nd_hasATrait(traits, ctxTraits, ctx) {
    return exists((x) => contains(x, ctxTraits), traits);
}

export const ADND2nd_rules = rulesOf([(() => {
    const tupledArg = op_EqualsEqualsGreater(new ADND2nd_Trait(0), map((arg0) => (new ADND2nd_Trait(2, arg0)), ofArray([new ADND2nd_Race(0), new ADND2nd_Race(1), new ADND2nd_Race(2), new ADND2nd_Race(3), new ADND2nd_Race(4), new ADND2nd_Race(5), new ADND2nd_Race(6)])));
    return ADND2nd_precondition((_arg1) => {
        let pattern_matching_result, ctx, ctx_2, ctx_4, ctx_6, ctx_8, ctx_10;
        if (_arg1[0].tag === 2) {
            if (_arg1[0].fields[0].tag === 1) {
                pattern_matching_result = 0;
                ctx = _arg1[1];
            }
            else if (_arg1[0].fields[0].tag === 3) {
                pattern_matching_result = 1;
                ctx_2 = _arg1[1];
            }
            else if (_arg1[0].fields[0].tag === 2) {
                pattern_matching_result = 2;
                ctx_4 = _arg1[1];
            }
            else if (_arg1[0].fields[0].tag === 4) {
                pattern_matching_result = 3;
                ctx_6 = _arg1[1];
            }
            else if (_arg1[0].fields[0].tag === 6) {
                pattern_matching_result = 4;
                ctx_8 = _arg1[1];
            }
            else if (_arg1[0].fields[0].tag === 5) {
                pattern_matching_result = 5;
                ctx_10 = _arg1[1];
            }
            else {
                pattern_matching_result = 6;
            }
        }
        else {
            pattern_matching_result = 6;
        }
        switch (pattern_matching_result) {
            case 0: {
                return ADND2nd_preracialStatMin(ofArray([[new Stat(1), 6], [new Stat(2), 7], [new Stat(3), 8], [new Stat(5), 8]]), ctx[0], ctx[1]);
            }
            case 1: {
                return ADND2nd_preracialStatMin(ofArray([[new Stat(1), 6], [new Stat(2), 6], [new Stat(3), 4]]), ctx_2[0], ctx_2[1]);
            }
            case 2: {
                return ADND2nd_preracialStatRange(ofArray([[new Stat(0), 8, 18], [new Stat(1), 3, 17], [new Stat(2), 11, 18], [new Stat(5), 3, 17]]), ctx_4[0], ctx_4[1]);
            }
            case 3: {
                return ADND2nd_preracialStatRange(ofArray([[new Stat(0), 3, 18], [new Stat(1), 12, 20], [new Stat(2), 3, 20], [new Stat(4), 7, 20]]), ctx_6[0], ctx_6[1]);
            }
            case 4: {
                return ADND2nd_preracialStatRange(ofArray([[new Stat(0), 8, 20], [new Stat(1), 15, 20], [new Stat(5), 3, 17]]), ctx_8[0], ctx_8[1]);
            }
            case 5: {
                return ADND2nd_preracialStatRange(ofArray([[new Stat(0), 17, 20], [new Stat(1), 3, 15], [new Stat(2), 15, 20], [new Stat(3), 3, 15], [new Stat(4), 3, 17], [new Stat(5), 3, 17]]), ctx_10[0], ctx_10[1]);
            }
            case 6: {
                return true;
            }
        }
    }, tupledArg[0], tupledArg[1]);
})(), (() => {
    let inputRecord;
    const tupledArg_1 = [new ADND2nd_Trait(0), (inputRecord = fresh([new ADND2nd_Trait(9, 60), new ADND2nd_Trait(9, 50), new ADND2nd_Trait(9, 40), new ADND2nd_Trait(9, 30), new ADND2nd_Trait(9, 20), new ADND2nd_Trait(9, 10)]), new Choice$2(inputRecord.options, inputRecord.preconditions, inputRecord.numberAllowed, inputRecord.mustBeDistinct, true, true))];
    return ADND2nd_precondition((_arg2) => {
        let pattern_matching_result_1, ctx_12, ctx_14, ctx_16, ctx_18, ctx_20, ctx_22;
        if (_arg2[0].tag === 9) {
            if (_arg2[0].fields[0] === 10) {
                pattern_matching_result_1 = 5;
                ctx_22 = _arg2[1];
            }
            else if (_arg2[0].fields[0] === 20) {
                pattern_matching_result_1 = 4;
                ctx_20 = _arg2[1];
            }
            else if (_arg2[0].fields[0] === 30) {
                pattern_matching_result_1 = 3;
                ctx_18 = _arg2[1];
            }
            else if (_arg2[0].fields[0] === 40) {
                pattern_matching_result_1 = 2;
                ctx_16 = _arg2[1];
            }
            else if (_arg2[0].fields[0] === 50) {
                pattern_matching_result_1 = 1;
                ctx_14 = _arg2[1];
            }
            else if (_arg2[0].fields[0] === 60) {
                pattern_matching_result_1 = 0;
                ctx_12 = _arg2[1];
            }
            else {
                pattern_matching_result_1 = 6;
            }
        }
        else {
            pattern_matching_result_1 = 6;
        }
        switch (pattern_matching_result_1) {
            case 0: {
                return ADND2nd_statRange(singleton([new Stat(2), 20, 20]), ctx_12[0], ctx_12[1]);
            }
            case 1: {
                return ADND2nd_statRange(singleton([new Stat(2), 21, 21]), ctx_14[0], ctx_14[1]);
            }
            case 2: {
                return ADND2nd_statRange(singleton([new Stat(2), 22, 22]), ctx_16[0], ctx_16[1]);
            }
            case 3: {
                return ADND2nd_statRange(singleton([new Stat(2), 23, 23]), ctx_18[0], ctx_18[1]);
            }
            case 4: {
                return ADND2nd_statRange(singleton([new Stat(2), 24, 24]), ctx_20[0], ctx_20[1]);
            }
            case 5: {
                return ADND2nd_statRange(singleton([new Stat(2), 25, 25]), ctx_22[0], ctx_22[1]);
            }
            case 6: {
                return false;
            }
        }
    }, tupledArg_1[0], tupledArg_1[1]);
})(), [new ADND2nd_Trait(0), (() => {
    const inputRecord_1 = fresh([new ADND2nd_Trait(3)]);
    return new Choice$2(inputRecord_1.options, inputRecord_1.preconditions, inputRecord_1.numberAllowed, inputRecord_1.mustBeDistinct, true, true);
})()], confer(new ADND2nd_Trait(2, new ADND2nd_Race(1)), ofArray([new ADND2nd_Trait(4, 1), new ADND2nd_Trait(1, new Stat(1), 1), new ADND2nd_Trait(1, new Stat(2), -1)])), confer(new ADND2nd_Trait(2, new ADND2nd_Race(5)), ofArray([new ADND2nd_Trait(5, 2), new ADND2nd_Trait(1, new Stat(0), 4), new ADND2nd_Trait(1, new Stat(2), 2), new ADND2nd_Trait(1, new Stat(3), -2), new ADND2nd_Trait(1, new Stat(4), -2), new ADND2nd_Trait(1, new Stat(5), -2)])), confer(new ADND2nd_Trait(2, new ADND2nd_Race(2)), ofArray([new ADND2nd_Trait(1, new Stat(2), 1), new ADND2nd_Trait(1, new Stat(5), -1)])), confer(new ADND2nd_Trait(2, new ADND2nd_Race(4)), ofArray([new ADND2nd_Trait(1, new Stat(1), 1), new ADND2nd_Trait(1, new Stat(0), -1)])), confer(new ADND2nd_Trait(2, new ADND2nd_Race(6)), ofArray([new ADND2nd_Trait(1, new Stat(1), 2), new ADND2nd_Trait(1, new Stat(4), 1), new ADND2nd_Trait(1, new Stat(3), -1), new ADND2nd_Trait(1, new Stat(5), -2)])), (() => {
    const tupledArg_2 = op_EqualsEqualsGreater(new ADND2nd_Trait(3), map((x) => (new ADND2nd_Trait(6, x, 1)), ofArray([new ADND2nd_CharacterClass(0), new ADND2nd_CharacterClass(1), new ADND2nd_CharacterClass(2), new ADND2nd_CharacterClass(3), new ADND2nd_CharacterClass(4), new ADND2nd_CharacterClass(5), new ADND2nd_CharacterClass(6), new ADND2nd_CharacterClass(7), new ADND2nd_CharacterClass(8), new ADND2nd_CharacterClass(9)])));
    return ADND2nd_precondition((_arg3) => {
        if (_arg3[0].tag === 6) {
            if (_arg3[0].fields[0].tag === 2) {
                const ctx_26 = _arg3[1];
                if (ADND2nd_statMin(ofArray([[new Stat(0), 12], [new Stat(2), 9], [new Stat(4), 13], [new Stat(5), 17]]), ctx_26[0], ctx_26[1])) {
                    return ADND2nd_hasTrait(new ADND2nd_Trait(2, new ADND2nd_Race(0)), ctx_26[0], ctx_26[1]);
                }
                else {
                    return false;
                }
            }
            else if (_arg3[0].fields[0].tag === 1) {
                const ctx_29 = _arg3[1];
                return ADND2nd_statMin(ofArray([[new Stat(0), 13], [new Stat(1), 13], [new Stat(2), 14], [new Stat(4), 14]]), ctx_29[0], ctx_29[1]);
            }
            else if (_arg3[0].fields[0].tag === 3) {
                const ctx_31 = _arg3[1];
                if (ADND2nd_statMin(singleton([new Stat(3), 9]), ctx_31[0], ctx_31[1])) {
                    return ADND2nd_hasATrait([new ADND2nd_Trait(2, new ADND2nd_Race(0)), new ADND2nd_Trait(2, new ADND2nd_Race(1)), new ADND2nd_Trait(2, new ADND2nd_Race(3))], ctx_31[0], ctx_31[1]);
                }
                else {
                    return false;
                }
            }
            else if (_arg3[0].fields[0].tag === 4) {
                const ctx_34 = _arg3[1];
                return ADND2nd_statMin(singleton([new Stat(4), 9]), ctx_34[0], ctx_34[1]);
            }
            else if (_arg3[0].fields[0].tag === 6) {
                const ctx_36 = _arg3[1];
                return ADND2nd_statMin(singleton([new Stat(4), 9]), ctx_36[0], ctx_36[1]);
            }
            else if (_arg3[0].fields[0].tag === 5) {
                const ctx_38 = _arg3[1];
                return ADND2nd_statMin(ofArray([[new Stat(4), 12], [new Stat(5), 15]]), ctx_38[0], ctx_38[1]);
            }
            else if (_arg3[0].fields[0].tag === 7) {
                const ctx_40 = _arg3[1];
                return ADND2nd_statMin(singleton([new Stat(1), 9]), ctx_40[0], ctx_40[1]);
            }
            else if (_arg3[0].fields[0].tag === 8) {
                const ctx_42 = _arg3[1];
                if (ADND2nd_statMin(ofArray([[new Stat(1), 12], [new Stat(3), 13], [new Stat(5), 15]]), ctx_42[0], ctx_42[1])) {
                    return ADND2nd_hasTrait(new ADND2nd_Trait(2, new ADND2nd_Race(0)), ctx_42[0], ctx_42[1]);
                }
                else {
                    return false;
                }
            }
            else if (_arg3[0].fields[0].tag === 9) {
                const ctx_45 = _arg3[1];
                return ADND2nd_statMin(ofArray([[new Stat(2), 11], [new Stat(3), 12], [new Stat(4), 15]]), ctx_45[0], ctx_45[1]);
            }
            else {
                const ctx_24 = _arg3[1];
                return ADND2nd_statMin(singleton([new Stat(0), 9]), ctx_24[0], ctx_24[1]);
            }
        }
        else {
            return true;
        }
    }, tupledArg_2[0], tupledArg_2[1]);
})(), op_EqualsEqualsGreater(new ADND2nd_Trait(6, new ADND2nd_CharacterClass(6), 1), map((arg0_1) => (new ADND2nd_Trait(7, arg0_1)), ADND2nd_WorshipFocus_get_All())), op_EqualsEqualsGreater(new ADND2nd_Trait(6, new ADND2nd_CharacterClass(9), 1), map((arg0_2) => (new ADND2nd_Trait(8, arg0_2)), ADND2nd_PsionicDiscipline_get_All())), confer(new ADND2nd_Trait(6, new ADND2nd_CharacterClass(0), 1), singleton(new ADND2nd_Trait(10)))]);

export function ADND2nd_strBonus(_arg1_0, _arg1_1) {
    let n, e_6, e_4, e_2, e;
    const _arg1 = [_arg1_0, _arg1_1];
    if ((n = (_arg1[0] | 0), n <= 1)) {
        const n_1 = _arg1[0] | 0;
        return [-5, -4];
    }
    else {
        let pattern_matching_result;
        if (_arg1[0] === 2) {
            pattern_matching_result = 0;
        }
        else if (_arg1[0] === 3) {
            pattern_matching_result = 1;
        }
        else if (_arg1[0] === 4) {
            pattern_matching_result = 2;
        }
        else if (_arg1[0] === 5) {
            pattern_matching_result = 2;
        }
        else if (_arg1[0] === 6) {
            pattern_matching_result = 3;
        }
        else if (_arg1[0] === 7) {
            pattern_matching_result = 3;
        }
        else if (_arg1[0] === 16) {
            pattern_matching_result = 4;
        }
        else if (_arg1[0] === 17) {
            pattern_matching_result = 5;
        }
        else if (_arg1[0] === 18) {
            if (_arg1[1] != null) {
                if ((e = (_arg1[1] | 0), e <= 50)) {
                    pattern_matching_result = 7;
                }
                else {
                    pattern_matching_result = 8;
                }
            }
            else {
                pattern_matching_result = 6;
            }
        }
        else {
            pattern_matching_result = 8;
        }
        switch (pattern_matching_result) {
            case 0: {
                return [-3, -2];
            }
            case 1: {
                return [-3, -1];
            }
            case 2: {
                return [-2, -1];
            }
            case 3: {
                return [-1, 0];
            }
            case 4: {
                return [0, 1];
            }
            case 5: {
                return [1, 1];
            }
            case 6: {
                return [1, 2];
            }
            case 7: {
                return [1, 3];
            }
            case 8: {
                let pattern_matching_result_1;
                if (_arg1[0] === 18) {
                    if (_arg1[1] != null) {
                        if ((e_2 = (_arg1[1] | 0), e_2 <= 75)) {
                            pattern_matching_result_1 = 0;
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
                        return [2, 3];
                    }
                    case 1: {
                        let pattern_matching_result_2;
                        if (_arg1[0] === 18) {
                            if (_arg1[1] != null) {
                                if ((e_4 = (_arg1[1] | 0), e_4 <= 90)) {
                                    pattern_matching_result_2 = 0;
                                }
                                else {
                                    pattern_matching_result_2 = 1;
                                }
                            }
                            else {
                                pattern_matching_result_2 = 1;
                            }
                        }
                        else {
                            pattern_matching_result_2 = 1;
                        }
                        switch (pattern_matching_result_2) {
                            case 0: {
                                return [2, 4];
                            }
                            case 1: {
                                let pattern_matching_result_3;
                                if (_arg1[0] === 18) {
                                    if (_arg1[1] != null) {
                                        if ((e_6 = (_arg1[1] | 0), e_6 <= 99)) {
                                            pattern_matching_result_3 = 0;
                                        }
                                        else {
                                            pattern_matching_result_3 = 1;
                                        }
                                    }
                                    else {
                                        pattern_matching_result_3 = 1;
                                    }
                                }
                                else {
                                    pattern_matching_result_3 = 1;
                                }
                                switch (pattern_matching_result_3) {
                                    case 0: {
                                        return [2, 5];
                                    }
                                    case 1: {
                                        let pattern_matching_result_4;
                                        if (_arg1[0] === 18) {
                                            if (_arg1[1] != null) {
                                                pattern_matching_result_4 = 0;
                                            }
                                            else {
                                                pattern_matching_result_4 = 8;
                                            }
                                        }
                                        else if (_arg1[0] === 19) {
                                            pattern_matching_result_4 = 1;
                                        }
                                        else if (_arg1[0] === 20) {
                                            pattern_matching_result_4 = 2;
                                        }
                                        else if (_arg1[0] === 21) {
                                            pattern_matching_result_4 = 3;
                                        }
                                        else if (_arg1[0] === 22) {
                                            pattern_matching_result_4 = 4;
                                        }
                                        else if (_arg1[0] === 23) {
                                            pattern_matching_result_4 = 5;
                                        }
                                        else if (_arg1[0] === 24) {
                                            pattern_matching_result_4 = 6;
                                        }
                                        else if (_arg1[0] === 25) {
                                            pattern_matching_result_4 = 7;
                                        }
                                        else {
                                            pattern_matching_result_4 = 8;
                                        }
                                        switch (pattern_matching_result_4) {
                                            case 0: {
                                                const e_8 = _arg1[1] | 0;
                                                return [3, 6];
                                            }
                                            case 1: {
                                                return [3, 7];
                                            }
                                            case 2: {
                                                return [3, 8];
                                            }
                                            case 3: {
                                                return [4, 9];
                                            }
                                            case 4: {
                                                return [4, 10];
                                            }
                                            case 5: {
                                                return [5, 11];
                                            }
                                            case 6: {
                                                return [6, 12];
                                            }
                                            case 7: {
                                                return [7, 14];
                                            }
                                            case 8: {
                                                return [0, 0];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

export function ADND2nd_dexACBonus(_arg1) {
    let n;
    if ((n = (_arg1 | 0), n <= 2)) {
        const n_1 = _arg1 | 0;
        return -5;
    }
    else {
        switch (_arg1) {
            case 3: {
                return -4;
            }
            case 4: {
                return -3;
            }
            case 5: {
                return -2;
            }
            case 6: {
                return -1;
            }
            case 15: {
                return 1;
            }
            case 16: {
                return 2;
            }
            case 17: {
                return 3;
            }
            case 18:
            case 19:
            case 20: {
                return 4;
            }
            case 21:
            case 22:
            case 23: {
                return 5;
            }
            case 24:
            case 25: {
                return 6;
            }
            default: {
                return 0;
            }
        }
    }
}

export function ADND2nd_conBonus(isWarrior, _arg1) {
    let n, n_2;
    if ((n = (_arg1 | 0), n <= 1)) {
        const n_1 = _arg1 | 0;
        return -3;
    }
    else {
        let pattern_matching_result;
        if (_arg1 === 2) {
            pattern_matching_result = 0;
        }
        else if (_arg1 === 3) {
            pattern_matching_result = 0;
        }
        else if (_arg1 === 4) {
            pattern_matching_result = 1;
        }
        else if (_arg1 === 5) {
            pattern_matching_result = 1;
        }
        else if (_arg1 === 6) {
            pattern_matching_result = 1;
        }
        else if (_arg1 === 15) {
            pattern_matching_result = 2;
        }
        else if (_arg1 === 16) {
            pattern_matching_result = 3;
        }
        else if ((n_2 = (_arg1 | 0), (n_2 > 16) && (!isWarrior))) {
            pattern_matching_result = 4;
        }
        else {
            pattern_matching_result = 5;
        }
        switch (pattern_matching_result) {
            case 0: {
                return -2;
            }
            case 1: {
                return -1;
            }
            case 2: {
                return 1;
            }
            case 3: {
                return 2;
            }
            case 4: {
                const n_3 = _arg1 | 0;
                return 2;
            }
            case 5: {
                switch (_arg1) {
                    case 17: {
                        return 3;
                    }
                    case 18: {
                        return 4;
                    }
                    case 19:
                    case 20: {
                        return 5;
                    }
                    case 21:
                    case 22:
                    case 23: {
                        return 6;
                    }
                    case 24:
                    case 25: {
                        return 7;
                    }
                    default: {
                        return 0;
                    }
                }
            }
        }
    }
}

export function ADND2nd_hpOf(con, isWarrior, hdMultiplier, lvl, class$0027) {
    let hp, bonus;
    const conBonus = ADND2nd_conBonus(isWarrior, con) | 0;
    const hpRoll = (dieSize) => {
        if (con < 20) {
            return rand(dieSize) | 0;
        }
        else if (con < 21) {
            return max((x, y) => comparePrimitives(x, y), 2, rand(dieSize)) | 0;
        }
        else if (con < 23) {
            return max((x_1, y_1) => comparePrimitives(x_1, y_1), 3, rand(dieSize)) | 0;
        }
        else {
            return max((x_2, y_2) => comparePrimitives(x_2, y_2), 4, rand(dieSize)) | 0;
        }
    };
    const d = (n) => {
        if (hdMultiplier === 1) {
            return rand(n) | 0;
        }
        else {
            return sum_2(initialize(hdMultiplier, (arg20$0040) => thunk1((x_3) => rand(x_3), n, arg20$0040)), {
                GetZero: () => 0,
                Add: (x_4, y_3) => (x_4 + y_3),
            }) | 0;
        }
    };
    const _arg1 = (class$0027.tag === 2) ? ((lvl <= 9) ? [d(10), conBonus] : [3, 0]) : ((class$0027.tag === 1) ? ((lvl <= 9) ? [d(10), conBonus] : [3, 0]) : ((class$0027.tag === 4) ? ((lvl <= 9) ? [d(8), conBonus] : [2, 0]) : ((class$0027.tag === 9) ? ((lvl <= 9) ? [d(8), conBonus] : [2, 0]) : ((class$0027.tag === 6) ? ((lvl <= 9) ? [d(8), conBonus] : [2, 0]) : ((class$0027.tag === 5) ? ((lvl <= 9) ? [d(8), conBonus] : [2, 0]) : ((class$0027.tag === 7) ? ((lvl <= 10) ? [d(6), conBonus] : [2, 0]) : ((class$0027.tag === 8) ? ((lvl <= 10) ? [d(6), conBonus] : [2, 0]) : ((class$0027.tag === 3) ? ((lvl <= 10) ? [d(4), conBonus] : [1, 0]) : ((lvl <= 9) ? [d(10), conBonus] : [3, 0])))))))));
    if ((hp = (_arg1[0] | 0), (bonus = (_arg1[1] | 0), ((hp + bonus) <= 0) && (lvl === 1)))) {
        const hp_1 = _arg1[0] | 0;
        const bonus_1 = _arg1[1] | 0;
        return [hp_1, op_UnaryNegation_Int32(hp_1) + 1];
    }
    else {
        const otherwise = _arg1;
        return otherwise;
    }
}

export function ADND2nd_describeTrait(_arg1) {
    let pattern_matching_result, n, stat, race, minutes, n_1, focus, discipline, class$0027, stat_1;
    if (_arg1.tag === 1) {
        pattern_matching_result = 0;
        n = _arg1.fields[1];
        stat = _arg1.fields[0];
    }
    else if (_arg1.tag === 2) {
        if (_arg1.fields[0].tag === 4) {
            pattern_matching_result = 1;
        }
        else if (_arg1.fields[0].tag === 5) {
            pattern_matching_result = 2;
        }
        else {
            pattern_matching_result = 3;
            race = _arg1.fields[0];
        }
    }
    else if (_arg1.tag === 5) {
        if (_arg1.fields[0] === 2) {
            pattern_matching_result = 4;
        }
        else {
            pattern_matching_result = 10;
            stat_1 = _arg1;
        }
    }
    else if (_arg1.tag === 9) {
        pattern_matching_result = 5;
        minutes = _arg1.fields[0];
    }
    else if (_arg1.tag === 4) {
        pattern_matching_result = 6;
        n_1 = _arg1.fields[0];
    }
    else if (_arg1.tag === 7) {
        pattern_matching_result = 7;
        focus = _arg1.fields[0];
    }
    else if (_arg1.tag === 8) {
        pattern_matching_result = 8;
        discipline = _arg1.fields[0];
    }
    else if (_arg1.tag === 6) {
        if (_arg1.fields[1] === 1) {
            pattern_matching_result = 9;
            class$0027 = _arg1.fields[0];
        }
        else {
            pattern_matching_result = 10;
            stat_1 = _arg1;
        }
    }
    else {
        pattern_matching_result = 10;
        stat_1 = _arg1;
    }
    switch (pattern_matching_result) {
        case 0: {
            return toText(interpolate("%+d%P() %P()", [n, stat]));
        }
        case 1: {
            return "Athasian halfling";
        }
        case 2: {
            return "Half-giant";
        }
        case 3: {
            return uncamel(`${race}`);
        }
        case 4: {
            return "Double HP rolls";
        }
        case 5: {
            return `Limited regeneration (1 HP every ${minutes} minutes)`;
        }
        case 6: {
            return toText(interpolate("%+d%P() to hit with swords and bows", [n_1]));
        }
        case 7: {
            return `of ${focus}`;
        }
        case 8: {
            switch (discipline.tag) {
                case 1: {
                    return "Psychokineticist";
                }
                case 2: {
                    return "Psychometabolist";
                }
                case 3: {
                    return "Psychoporter";
                }
                case 4: {
                    return "Telepath";
                }
                case 5: {
                    return "Metapsionicist";
                }
                default: {
                    return "Clairsentient";
                }
            }
        }
        case 9: {
            return toString(class$0027);
        }
        case 10: {
            return uncamel(toString(stat_1));
        }
    }
}

export class DND5e_CharacterClass extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Artificer", "Bard", "Barbarian", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"];
    }
}

export function DND5e_CharacterClass$reflection() {
    return union_type("Domain.Character.DND5e.CharacterClass", [], DND5e_CharacterClass, () => [[], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export function DND5e_CharacterClass_get_All() {
    return ofArray([new DND5e_CharacterClass(0), new DND5e_CharacterClass(1), new DND5e_CharacterClass(2), new DND5e_CharacterClass(3), new DND5e_CharacterClass(4), new DND5e_CharacterClass(5), new DND5e_CharacterClass(6), new DND5e_CharacterClass(7), new DND5e_CharacterClass(8), new DND5e_CharacterClass(9), new DND5e_CharacterClass(10), new DND5e_CharacterClass(11), new DND5e_CharacterClass(12)]);
}

export class DND5e_CharacterSubclass extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["AlchemistArtificer", "ArtilleristArtificer", "BattlesmithArtificer", "LoreBard", "ValorBard", "BerserkerBarbarian", "TotemBarbarian", "ZealotBarbarian", "StormsBarbarian", "KnowledgeCleric", "LifeCleric", "LightCleric", "NatureCleric", "TempestCleric", "TrickeryCleric", "WarCleric", "ForgeCleric", "MoonDruid", "LandDruid", "ChampionFighter", "BattlemasterFighter", "EldritchKnightFighter", "OpenHandMonk", "ShadowMonk", "ElementalMonk", "LongDeathMonk", "KenseiMonk", "DrunkenMasterMonk", "DevotionPaladin", "AncientsPaladin", "VengeancePaladin", "ConquestPaladin", "BeastmasterRanger", "HunterRanger", "GloomstalkerRanger", "ThiefRogue", "AssassinRogue", "ArcaneTricksterRogue", "SwashbucklerRogue", "MastermindRogue", "ScoutRogue", "DraconicSorcerer", "WildSorcerer", "ShadowSorcerer", "ClockworkSorcerer", "AberrantMindSorcerer", "FiendWarlock", "ArchfeyWarlock", "GreatOldOneWarlock", "HexbladeWarlock", "FathomlessWarlock", "GenieWarlock", "AbjurorWizard", "ConjurorWizard", "DivinerWizard", "EnchanterWizard", "EvokerWizard", "IllusionistWizard", "NecromancerWizard", "TransmuterWizard"];
    }
}

export function DND5e_CharacterSubclass$reflection() {
    return union_type("Domain.Character.DND5e.CharacterSubclass", [], DND5e_CharacterSubclass, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class DND5e_Trait extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["PC", "StartingClass", "Race", "Level", "Subclass", "Human", "StandardHuman", "VariantHuman", "Elf", "WoodElf", "HighElf", "DrowElf", "Dwarf", "HillDwarf", "MountainDwarf", "Goblin", "StatMod", "Feat", "GreatWeaponMaster", "PolearmMaster", "Sharpshooter", "CrossbowExpert", "Tough", "Lucky", "Mobile", "ModeratelyArmored", "HeavyArmorMaster", "BonusWizardCantrip", "Cantrip", "MaskOfTheWild", "Faster", "SunlightSensitivity", "ImprovedDarkvision", "ShieldProficiency", "LightArmorProficiency", "MediumArmorProficiency", "HeavyArmorProficiency", "MartialWeaponProficiency", "Hexblade\u0027sCurse", "NimbleEscape", "ExtraHPPerLevel", "ExtraAttack", "PackTactics", "MartialAdvantage2d6"];
    }
}

export function DND5e_Trait$reflection() {
    return union_type("Domain.Character.DND5e.Trait", [], DND5e_Trait, () => [[], [], [], [["class\u0027", DND5e_CharacterClass$reflection()], ["level", int32_type]], [["Item", DND5e_CharacterSubclass$reflection()]], [], [], [], [], [], [], [], [], [], [], [], [["Item1", Stat$reflection()], ["Item2", int32_type]], [], [], [], [], [], [], [], [], [], [], [], [["Item", string_type]], [], [["Item", int32_type]], [], [], [], [], [], [], [], [], [], [["Item", int32_type]], [["extras", int32_type]], [], []]);
}

export function DND5e_describeTrait(_arg1) {
    let pattern_matching_result, n, stat, n_1, cantrip, n_2, cl, subclass, stat_1;
    if (_arg1.tag === 16) {
        pattern_matching_result = 0;
        n = _arg1.fields[1];
        stat = _arg1.fields[0];
    }
    else if (_arg1.tag === 40) {
        pattern_matching_result = 1;
        n_1 = _arg1.fields[0];
    }
    else if (_arg1.tag === 28) {
        pattern_matching_result = 2;
        cantrip = _arg1.fields[0];
    }
    else if (_arg1.tag === 30) {
        pattern_matching_result = 3;
        n_2 = _arg1.fields[0];
    }
    else if (_arg1.tag === 3) {
        if (_arg1.fields[1] === 0) {
            pattern_matching_result = 4;
            cl = _arg1.fields[0];
        }
        else {
            pattern_matching_result = 6;
            stat_1 = _arg1;
        }
    }
    else if (_arg1.tag === 4) {
        pattern_matching_result = 5;
        subclass = _arg1.fields[0];
    }
    else {
        pattern_matching_result = 6;
        stat_1 = _arg1;
    }
    switch (pattern_matching_result) {
        case 0: {
            return toText(interpolate("%+d%P() %P()", [n, stat]));
        }
        case 1: {
            return `${n_1} extra HP per level`;
        }
        case 2: {
            return `${cantrip}`;
        }
        case 3: {
            return toText(interpolate("%+d%P()\u0027 speed", [n_2]));
        }
        case 4: {
            return `${cl}`;
        }
        case 5: {
            const full = uncamel(toString(subclass));
            return full.slice(void 0, (full.lastIndexOf(" ") - 1) + 1);
        }
        case 6: {
            return uncamel(toString(stat_1));
        }
    }
}

export class DND5e_CharacterSheet extends Record {
    constructor(id, name, origin, sex, Str, Dex, Con, Int, Wis, Cha, originalRolls, hp, ac, toHit, damage, xp, levels, traits, wealth) {
        super();
        this.id = id;
        this.name = name;
        this.origin = origin;
        this.sex = sex;
        this.Str = (Str | 0);
        this.Dex = (Dex | 0);
        this.Con = (Con | 0);
        this.Int = (Int | 0);
        this.Wis = (Wis | 0);
        this.Cha = (Cha | 0);
        this.originalRolls = originalRolls;
        this.hp = hp;
        this.ac = (ac | 0);
        this.toHit = (toHit | 0);
        this.damage = damage;
        this.xp = (xp | 0);
        this.levels = levels;
        this.traits = traits;
        this.wealth = (wealth | 0);
    }
}

export function DND5e_CharacterSheet$reflection() {
    return record_type("Domain.Character.DND5e.CharacterSheet", [], DND5e_CharacterSheet, () => [["id", option_type(int32_type)], ["name", string_type], ["origin", Origin$reflection()], ["sex", Sex$reflection()], ["Str", int32_type], ["Dex", int32_type], ["Con", int32_type], ["Int", int32_type], ["Wis", int32_type], ["Cha", int32_type], ["originalRolls", array_type(int32_type)], ["hp", array_type(tuple_type(int32_type, int32_type))], ["ac", int32_type], ["toHit", int32_type], ["damage", RollSpec$reflection()], ["xp", int32_type], ["levels", array_type(tuple_type(DND5e_CharacterClass$reflection(), int32_type))], ["traits", Setting$2$reflection(DND5e_Trait$reflection(), class_type("Microsoft.FSharp.Collections.FSharpSet`1", [DND5e_Trait$reflection()]))], ["wealth", int32_type]]);
}

export const DND5e_races = ofArray([new DND5e_Trait(5), new DND5e_Trait(8), new DND5e_Trait(12), new DND5e_Trait(15)]);

export const DND5e_feats = ofArray([new DND5e_Trait(18), new DND5e_Trait(19), new DND5e_Trait(20), new DND5e_Trait(21), new DND5e_Trait(22), new DND5e_Trait(23), new DND5e_Trait(24), new DND5e_Trait(25), new DND5e_Trait(26)]);

export function DND5e_precondition(pattern, head, options) {
    return [head, new Choice$2(options.options, (tupledArg) => {
        const trait1 = tupledArg[0];
        const _arg1 = tupledArg[1];
        const traits = _arg1[0];
        const ctx = _arg1[1];
        return pattern([trait1, [traits, ctx]]);
    }, options.numberAllowed, options.mustBeDistinct, options.elideFromDisplayAndSummary, options.autopick)];
}

export function DND5e_statMin(prereqs, _arg1, stats) {
    return List_every((tupledArg) => {
        const stat = tupledArg[0];
        const minimum = tupledArg[1] | 0;
        return FSharpMap__get_Item(stats, stat) >= minimum;
    })(prereqs);
}

export function DND5e_statRange(prereqs, _arg1, stats) {
    return List_every((tupledArg) => {
        const stat = tupledArg[0];
        const minimum = tupledArg[1] | 0;
        const maximum = tupledArg[2] | 0;
        return (minimum <= FSharpMap__get_Item(stats, stat)) && (FSharpMap__get_Item(stats, stat) <= maximum);
    })(prereqs);
}

export function DND5e_hasTrait(trait1, traits, _arg1) {
    return contains(trait1, traits);
}

export function DND5e_hpOf(lvl, _arg1) {
    switch (_arg1.tag) {
        case 5:
        case 7:
        case 8: {
            if (lvl === 1) {
                return 10;
            }
            else {
                return 6;
            }
        }
        case 0:
        case 1:
        case 6:
        case 3:
        case 4:
        case 11:
        case 9: {
            if (lvl === 1) {
                return 8;
            }
            else {
                return 5;
            }
        }
        case 10:
        case 12: {
            if (lvl === 1) {
                return 6;
            }
            else {
                return 4;
            }
        }
        default: {
            if (lvl === 1) {
                return 12;
            }
            else {
                return 7;
            }
        }
    }
}

export function DND5e_statBonus(statValue) {
    return (~(~(statValue / 2))) - 5;
}

export function DND5e_proficiencyBonus(traits) {
    return 1 + (~(~((sum_3(map_1((arg_1) => max_1(map_1((tuple_2) => tuple_2[1], arg_1[1]), {
        Compare: (x_1, y_1) => comparePrimitives(x_1, y_1),
    }), groupBy((tuple) => tuple[0], choose((_arg1) => {
        if (_arg1.tag === 3) {
            const lvl = _arg1.fields[1] | 0;
            const class$0027 = _arg1.fields[0];
            return [class$0027, lvl];
        }
        else {
            return void 0;
        }
    }, traits), {
        Equals: (x, y) => equals(x, y),
        GetHashCode: (x) => safeHash(x),
    })), {
        GetZero: () => 0,
        Add: (x_2, y_2) => (x_2 + y_2),
    }) + 3) / 4)));
}

export const DND5e_rules = rulesOf(toList(delay(() => {
    let inputRecord;
    return append(singleton_1([new DND5e_Trait(0), (inputRecord = fresh([new DND5e_Trait(2), new DND5e_Trait(1)]), new Choice$2(inputRecord.options, inputRecord.preconditions, inputRecord.numberAllowed, inputRecord.mustBeDistinct, true, true))]), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(2), DND5e_races)), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(1), toList(delay(() => map_1((cl) => (new DND5e_Trait(3, cl, 0)), DND5e_CharacterClass_get_All()))))), delay(() => {
        const stats = ofArray([new Stat(0), new Stat(1), new Stat(2), new Stat(3), new Stat(4), new Stat(5)]);
        return append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(5), ofArray([new DND5e_Trait(6), new DND5e_Trait(7)]))), delay(() => append(singleton_1(confer(new DND5e_Trait(6), toList(delay(() => map_1((stat) => (new DND5e_Trait(16, stat, 1)), Stat_get_All()))))), delay(() => {
            let inputRecord_1;
            return append(singleton_1([new DND5e_Trait(7), (inputRecord_1 = fresh(map((x) => (new DND5e_Trait(16, x, 1)), stats)), new Choice$2(inputRecord_1.options, inputRecord_1.preconditions, 2, true, inputRecord_1.elideFromDisplayAndSummary, inputRecord_1.autopick))]), delay(() => append(singleton_1(invisiblyConfer(new DND5e_Trait(7), singleton(new DND5e_Trait(17)))), delay(() => {
                let tupledArg;
                return append(singleton_1((tupledArg = op_EqualsEqualsGreater(new DND5e_Trait(17), DND5e_feats), DND5e_precondition((_arg1) => {
                    if (_arg1[0].tag === 26) {
                        const ctx = _arg1[1];
                        return DND5e_hasTrait(new DND5e_Trait(36), ctx[0], ctx[1]);
                    }
                    else if (_arg1[0].tag === 36) {
                        const ctx_1 = _arg1[1];
                        return DND5e_hasTrait(new DND5e_Trait(35), ctx_1[0], ctx_1[1]);
                    }
                    else if (_arg1[0].tag === 25) {
                        const ctx_2 = _arg1[1];
                        return DND5e_hasTrait(new DND5e_Trait(34), ctx_2[0], ctx_2[1]);
                    }
                    else {
                        return true;
                    }
                }, tupledArg[0], tupledArg[1]))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(8), ofArray([new DND5e_Trait(10), new DND5e_Trait(9), new DND5e_Trait(11)]))), delay(() => append(singleton_1(confer(new DND5e_Trait(10), singleton(new DND5e_Trait(27)))), delay(() => append(singleton_1(confer(new DND5e_Trait(9), ofArray([new DND5e_Trait(29), new DND5e_Trait(30, 5)]))), delay(() => append(singleton_1(confer(new DND5e_Trait(11), ofArray([new DND5e_Trait(32), new DND5e_Trait(31)]))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(27), ofArray([new DND5e_Trait(28, "Fire Bolt"), new DND5e_Trait(28, "Minor Illusion"), new DND5e_Trait(28, "Blade Ward"), new DND5e_Trait(28, "Toll the Dead")]))), delay(() => append(singleton_1(confer(new DND5e_Trait(12), ofArray([new DND5e_Trait(16, new Stat(2), 2), new DND5e_Trait(30, -5)]))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(12), ofArray([new DND5e_Trait(13), new DND5e_Trait(14)]))), delay(() => append(singleton_1(confer(new DND5e_Trait(13), ofArray([new DND5e_Trait(40, 1), new DND5e_Trait(16, new Stat(4), 1)]))), delay(() => append(singleton_1(confer(new DND5e_Trait(14), ofArray([new DND5e_Trait(35), new DND5e_Trait(16, new Stat(0), 2)]))), delay(() => append(singleton_1(confer(new DND5e_Trait(15), ofArray([new DND5e_Trait(39), new DND5e_Trait(16, new Stat(1), 2), new DND5e_Trait(16, new Stat(2), 1)]))), delay(() => append(singleton_1(confer(new DND5e_Trait(22), singleton(new DND5e_Trait(40, 2)))), delay(() => append(singleton_1(confer(new DND5e_Trait(26), singleton(new DND5e_Trait(16, new Stat(0), 1)))), delay(() => append(singleton_1(confer(new DND5e_Trait(25), ofArray([new DND5e_Trait(16, new Stat(1), 1), new DND5e_Trait(35), new DND5e_Trait(33)]))), delay(() => append(singleton_1(confer(new DND5e_Trait(24), singleton(new DND5e_Trait(30, 10)))), delay(() => {
                    const subclass = (lst) => map((arg0) => (new DND5e_Trait(4, arg0)), lst);
                    return append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(0), 3), subclass(ofArray([new DND5e_CharacterSubclass(0), new DND5e_CharacterSubclass(1), new DND5e_CharacterSubclass(2)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(1), 3), subclass(ofArray([new DND5e_CharacterSubclass(3), new DND5e_CharacterSubclass(4)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(2), 3), subclass(ofArray([new DND5e_CharacterSubclass(5), new DND5e_CharacterSubclass(6), new DND5e_CharacterSubclass(7), new DND5e_CharacterSubclass(8)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(3), 1), subclass(ofArray([new DND5e_CharacterSubclass(9), new DND5e_CharacterSubclass(10), new DND5e_CharacterSubclass(11), new DND5e_CharacterSubclass(12), new DND5e_CharacterSubclass(13), new DND5e_CharacterSubclass(14), new DND5e_CharacterSubclass(15), new DND5e_CharacterSubclass(16)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(4), 2), subclass(ofArray([new DND5e_CharacterSubclass(17), new DND5e_CharacterSubclass(18)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(5), 3), subclass(ofArray([new DND5e_CharacterSubclass(19), new DND5e_CharacterSubclass(20), new DND5e_CharacterSubclass(21)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(6), 3), subclass(ofArray([new DND5e_CharacterSubclass(22), new DND5e_CharacterSubclass(23), new DND5e_CharacterSubclass(24), new DND5e_CharacterSubclass(25), new DND5e_CharacterSubclass(26), new DND5e_CharacterSubclass(27)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(7), 3), subclass(ofArray([new DND5e_CharacterSubclass(28), new DND5e_CharacterSubclass(29), new DND5e_CharacterSubclass(30), new DND5e_CharacterSubclass(31)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(8), 3), subclass(ofArray([new DND5e_CharacterSubclass(32), new DND5e_CharacterSubclass(33), new DND5e_CharacterSubclass(34)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(9), 3), subclass(ofArray([new DND5e_CharacterSubclass(35), new DND5e_CharacterSubclass(36), new DND5e_CharacterSubclass(37), new DND5e_CharacterSubclass(38), new DND5e_CharacterSubclass(39), new DND5e_CharacterSubclass(40)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(10), 1), subclass(ofArray([new DND5e_CharacterSubclass(41), new DND5e_CharacterSubclass(42), new DND5e_CharacterSubclass(43), new DND5e_CharacterSubclass(44), new DND5e_CharacterSubclass(45)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(11), 1), subclass(ofArray([new DND5e_CharacterSubclass(46), new DND5e_CharacterSubclass(47), new DND5e_CharacterSubclass(48), new DND5e_CharacterSubclass(49), new DND5e_CharacterSubclass(50), new DND5e_CharacterSubclass(51)])))), delay(() => append(singleton_1(op_EqualsEqualsGreater(new DND5e_Trait(3, new DND5e_CharacterClass(12), 2), subclass(ofArray([new DND5e_CharacterSubclass(52), new DND5e_CharacterSubclass(53), new DND5e_CharacterSubclass(54), new DND5e_CharacterSubclass(55), new DND5e_CharacterSubclass(56), new DND5e_CharacterSubclass(57), new DND5e_CharacterSubclass(58), new DND5e_CharacterSubclass(59)])))), delay(() => append(map_1((class$0027) => invisiblyConfer(new DND5e_Trait(3, class$0027, 0), singleton(new DND5e_Trait(3, class$0027, 1))), DND5e_CharacterClass_get_All()), delay(() => append(map_1((class$0027_1) => confer(new DND5e_Trait(3, class$0027_1, 0), ofArray([new DND5e_Trait(36), new DND5e_Trait(33)])), [new DND5e_CharacterClass(5), new DND5e_CharacterClass(7)]), delay(() => append(map_1((class$0027_2) => confer(new DND5e_Trait(3, class$0027_2, 0), ofArray([new DND5e_Trait(35), new DND5e_Trait(33)])), [new DND5e_CharacterClass(3), new DND5e_CharacterClass(8), new DND5e_CharacterClass(4), new DND5e_CharacterClass(2), new DND5e_CharacterClass(0)]), delay(() => append(map_1((class$0027_3) => confer(new DND5e_Trait(3, class$0027_3, 0), singleton(new DND5e_Trait(34))), [new DND5e_CharacterClass(9), new DND5e_CharacterClass(11), new DND5e_CharacterClass(1)]), delay(() => append(map_1((subclass_1) => confer(new DND5e_Trait(4, subclass_1), singleton(new DND5e_Trait(36))), [new DND5e_CharacterSubclass(10), new DND5e_CharacterSubclass(12), new DND5e_CharacterSubclass(13), new DND5e_CharacterSubclass(15), new DND5e_CharacterSubclass(16)]), delay(() => append(singleton_1(confer(new DND5e_Trait(4, new DND5e_CharacterSubclass(49)), ofArray([new DND5e_Trait(35), new DND5e_Trait(33), new DND5e_Trait(37), new DND5e_Trait(38)]))), delay(() => append(map_1((class$0027_4) => confer(new DND5e_Trait(3, class$0027_4, 5), singleton(new DND5e_Trait(41, 1))), [new DND5e_CharacterClass(5), new DND5e_CharacterClass(7), new DND5e_CharacterClass(8), new DND5e_CharacterClass(2)]), delay(() => append(singleton_1(confer(new DND5e_Trait(3, new DND5e_CharacterClass(5), 11), singleton(new DND5e_Trait(41, 2)))), delay(() => singleton_1(confer(new DND5e_Trait(3, new DND5e_CharacterClass(5), 20), singleton(new DND5e_Trait(41, 3))))))))))))))))))))))))))))))))))))))))))))));
                }))))))))))))))))))))))))))))));
            }))));
        }))));
    }))))));
})));

export class Universal_Detail$2 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Detail2e", "Detail5e"];
    }
}

export function Universal_Detail$2$reflection(gen0, gen1) {
    return union_type("Domain.Character.Universal.Detail`2", [gen0, gen1], Universal_Detail$2, () => [[["Item", gen0]], [["Item", gen1]]]);
}

export function Universal_Detail$2__get_isADND(this$) {
    if (this$.tag === 1) {
        return false;
    }
    else {
        return true;
    }
}

export function Universal_Detail$2__get_is5E(this$) {
    if (this$.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function Universal_Detail$2__map2e_Z1FC644CA(this$, f) {
    if (this$.tag === 0) {
        const instance = this$.fields[0];
        return new Universal_Detail$2(0, f(instance));
    }
    else {
        const unchanged = this$;
        return unchanged;
    }
}

export function Universal_Detail$2__map5e_Z1D9544EA(this$, f) {
    if (this$.tag === 1) {
        const instance = this$.fields[0];
        return new Universal_Detail$2(1, f(instance));
    }
    else {
        const unchanged = this$;
        return unchanged;
    }
}

export function Universal_Detail$2__map_Z1FC644CA(this$, f) {
    if (this$.tag === 0) {
        const instance = this$.fields[0];
        return new Universal_Detail$2(0, f(instance));
    }
    else {
        const unchanged = this$;
        return unchanged;
    }
}

export function Universal_Detail$2__map_Z1D9544EA(this$, f) {
    if (this$.tag === 1) {
        const instance = this$.fields[0];
        return new Universal_Detail$2(1, f(instance));
    }
    else {
        const unchanged = this$;
        return unchanged;
    }
}

export function Universal_Detail$2__converge_Z191A36BF(this$, f2e, f5e) {
    if (this$.tag === 1) {
        const data_1 = this$.fields[0];
        return f5e(data_1);
    }
    else {
        const data = this$.fields[0];
        return f2e(data);
    }
}

export function Universal_$007CIsADND$007C_$007C(_arg1) {
    if (_arg1.tag === 0) {
        const x = _arg1.fields[0];
        return some(x);
    }
    else {
        return void 0;
    }
}

export function Universal_$007CIs5e$007C_$007C(_arg1) {
    if (_arg1.tag === 1) {
        const x = _arg1.fields[0];
        return some(x);
    }
    else {
        return void 0;
    }
}

export const Universal_rules2e = ADND2nd_rules;

export const Universal_rules5e = DND5e_rules;

export function Universal_$007CGenericCharacterSheet$007C(_arg1) {
    if (_arg1.tag === 1) {
        const char_1 = _arg1.fields[0];
        return {
            Cha: char_1.Cha,
            Con: char_1.Con,
            Dex: char_1.Dex,
            Int: char_1.Int,
            Str: char_1.Str,
            Wis: char_1.Wis,
            ac: char_1.ac,
            exceptionalStrength: void 0,
            hp: char_1.hp,
            name: char_1.name,
            origin: char_1.origin,
            sex: char_1.sex,
        };
    }
    else {
        const char = _arg1.fields[0];
        return {
            Cha: char.Cha,
            Con: char.Con,
            Dex: char.Dex,
            Int: char.Int,
            Str: char.Str,
            Wis: char.Wis,
            ac: char.ac,
            exceptionalStrength: char.exceptionalStrength,
            hp: char.hp,
            name: char.name,
            origin: char.origin,
            sex: char.sex,
        };
    }
}

export function makeName(sex_mut) {
    makeName:
    while (true) {
        const sex = sex_mut;
        const nationOfOrigin = chooseRandom(["Tir na n\u0027Og", "Abysia", "Kailasa", "Ermor", "Undauntra", "Arboria", "Mordor"]);
        const chooseFromLists = (_arg1_mut) => {
            chooseFromLists:
            while (true) {
                const _arg1 = _arg1_mut;
                if (isEmpty(_arg1)) {
                    return "";
                }
                else {
                    const rest = tail(_arg1);
                    const potentialCategory = head_3(_arg1);
                    const matchValue = tryFind([nationOfOrigin, potentialCategory], nameLists);
                    if (matchValue == null) {
                        _arg1_mut = rest;
                        continue chooseFromLists;
                    }
                    else {
                        const nameList = matchValue;
                        return chooseRandom(nameList);
                    }
                }
                break;
            }
        };
        const firstName = chooseFromLists(singleton(toString(sex)));
        if (firstName === "") {
            sex_mut = sex;
            continue makeName;
        }
        else {
            const lastName = (name) => {
                const surname = chooseFromLists(ofArray(["Last", `Cognomen${sex}`, `Last${sex}`]));
                return (`${name} ${surname}`).trim();
            };
            const prefix = (name_1) => {
                const prefixes = ofArray(["Insanity", "Black", "Merciless", "Gentle", "Calamity"]);
                return (`${chooseRandom(prefixes)} ${name_1}`).trim();
            };
            const title = (name_2) => {
                const suffixes = ofArray(["Defender of Humanity", "Last of the Dwarflords", "the Accursed", "Esquire", "the Undying"]);
                return (`${name_2}, ${chooseRandom(suffixes)}`).trim();
            };
            const allThree = (arg_1) => title(lastName(prefix(arg_1)));
            return [nationOfOrigin, chooseRandomExponentialDecay(0.4, ofArray([lastName, (arg_2) => title(lastName(arg_2)), prefix, allThree]))(firstName)];
        }
        break;
    }
}

//# sourceMappingURL=Character.fs.js.map
