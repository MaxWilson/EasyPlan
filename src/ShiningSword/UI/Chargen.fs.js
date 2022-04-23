import { toString as toString_1, Record, Union } from "../fable_modules/fable-library.3.6.2/Types.js";
import { lambda_type, record_type, class_type, array_type, tuple_type, option_type, string_type, union_type, int32_type } from "../fable_modules/fable-library.3.6.2/Reflection.js";
import { DND5e_rules, Origin, Universal_Detail$2__converge_Z191A36BF, ADND2nd_PreconditionContext, Universal_$007CGenericCharacterSheet$007C, ADND2nd_CharacterClass, ADND2nd_rules, ADND2nd_describeTrait, DND5e_races, DND5e_describeTrait, Universal_Detail$2__map2e_Z1FC644CA, Universal_Detail$2__map5e_Z1D9544EA, Universal_Detail$2, DND5e_CharacterSheet$reflection, ADND2nd_CharacterSheet$reflection, Universal_Detail$2__get_isADND, makeName, Sex, Stat_get_All, DND5e_CharacterSheet, DND5e_proficiencyBonus, DND5e_statBonus, DND5e_hpOf, DND5e_Trait, Universal_rules5e, Universal_$007CIs5e$007C_$007C, Stat, ADND2nd_CharacterSheet, RollSpec_op_Addition_Z57C2BA88, ADND2nd_strBonus, RollSpec_create_4F7761DC, RollSpec_create_Z37302880, ADND2nd_dexACBonus, ADND2nd_hpOf, ADND2nd_Trait, Universal_rules2e, Universal_$007CIsADND$007C_$007C, Universal_Detail$2$reflection, DND5e_Trait$reflection, ADND2nd_Trait$reflection, Stat$reflection, Sex$reflection } from "../../Lib/Character.fs.js";
import { empty as empty_2, append as append_1, pick, find, filter, length, toList, singleton, collect, delay, toArray, maxBy, tryPick, exists, choose, max, map as map_2, fold } from "../fable_modules/fable-library.3.6.2/Seq.js";
import { tryFind, empty, change } from "../fable_modules/fable-library.3.6.2/Map.js";
import { structuralHash, createObj, int32ToString, count as count_1, equalArrays, max as max_1, min as min_1, safeHash, equals, comparePrimitives, compare, partialApply } from "../fable_modules/fable-library.3.6.2/Util.js";
import { summarize, collect as collect_1, $007CHasTrait$007C, toggleTrait, toSetting } from "../../Lib/DerivedTraits.fs.js";
import { filter as filter_1, contains, ofList, FSharpSet__Contains, ofSeq } from "../fable_modules/fable-library.3.6.2/Set.js";
import { groupBy } from "../fable_modules/fable-library.3.6.2/Seq2.js";
import { value as value_96, map as map_4, defaultArg } from "../fable_modules/fable-library.3.6.2/Option.js";
import { tuple2, String_join, String_oxfordJoin, chooseRandom, shouldntHappen, thunk1, rand, $007CLookup$007C_$007C } from "../../Lib/Common.fs.js";
import { choose as choose_1, contains as contains_2, sumBy, tryPick as tryPick_1, mapIndexed, append, map as map_3, equalsWith } from "../fable_modules/fable-library.3.6.2/Array.js";
import { exists as exists_1, choose as choose_2, map as map_5, append as append_2, mapIndexed as mapIndexed_1, singleton as singleton_1, contains as contains_1, length as length_1, ofArray, toArray as toArray_1, item, empty as empty_1, cons, tail, head as head_2, isEmpty, sortDescending, take, initialize, sum } from "../fable_modules/fable-library.3.6.2/List.js";
import { rangeDouble } from "../fable_modules/fable-library.3.6.2/Range.js";
import { join, interpolate, toText, printf, toConsole } from "../fable_modules/fable-library.3.6.2/String.js";
import { Cmd_batch } from "../fable_modules/Fable.Elmish.3.1.0/cmd.fs.js";
import { getItemFromDict } from "../fable_modules/fable-library.3.6.2/MapUtil.js";
import { createElement } from "react";
import * as react from "react";
import { Interop_reactApi } from "../fable_modules/Feliz.1.61.0/Interop.fs.js";
import { container, target as target_2, prop } from "./DragDrop.fs.js";
import { useReact_useEffectOnce_3A5B6456, useReact_useRef_1505 } from "../fable_modules/Feliz.1.61.0/React.fs.js";

export class Interaction_Mode extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["CumulativeFrom", "Assign", "InOrder", "PointBuy"];
    }
}

export function Interaction_Mode$reflection() {
    return union_type("UI.Chargen.Interaction.Mode", [], Interaction_Mode, () => [[["min", int32_type], ["max", int32_type]], [], [], []]);
}

export class Interaction_Draft extends Record {
    constructor(name, nationalOrigin, sex, allocations, exceptionalStrength, originalRolls, mode, decisions) {
        super();
        this.name = name;
        this.nationalOrigin = nationalOrigin;
        this.sex = sex;
        this.allocations = allocations;
        this.exceptionalStrength = exceptionalStrength;
        this.originalRolls = originalRolls;
        this.mode = mode;
        this.decisions = decisions;
    }
}

export function Interaction_Draft$reflection() {
    return record_type("UI.Chargen.Interaction.Draft", [], Interaction_Draft, () => [["name", string_type], ["nationalOrigin", string_type], ["sex", Sex$reflection()], ["allocations", array_type(tuple_type(int32_type, option_type(Stat$reflection())))], ["exceptionalStrength", option_type(int32_type)], ["originalRolls", array_type(int32_type)], ["mode", Interaction_Mode$reflection()], ["decisions", Universal_Detail$2$reflection(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [ADND2nd_Trait$reflection(), class_type("Microsoft.FSharp.Collections.FSharpMap`2", [int32_type, array_type(int32_type)])]), class_type("Microsoft.FSharp.Collections.FSharpMap`2", [DND5e_Trait$reflection(), class_type("Microsoft.FSharp.Collections.FSharpMap`2", [int32_type, array_type(int32_type)])]))]]);
}

export function Interaction_addUpStats(statMods) {
    const addStat = (n, _arg1) => {
        if (_arg1 == null) {
            return n;
        }
        else {
            const current = _arg1 | 0;
            return current + n;
        }
    };
    return fold((map, tupledArg) => {
        const stat = tupledArg[0];
        const n_1 = tupledArg[1] | 0;
        return change(stat, partialApply(1, addStat, [n_1]), map);
    }, empty(), statMods);
}

export function Interaction_$007CCharacterSheet2E$007C_$007C(ctx, makeOrigin, draft) {
    let source_19;
    const activePatternResult15385 = Universal_$007CIsADND$007C_$007C(draft.decisions);
    if (activePatternResult15385 != null) {
        const decisions = activePatternResult15385;
        const matchValue_1 = ctx.postracialStats;
        let pattern_matching_result, cha, con, dex, int, str, wis;
        const activePatternResult15379 = $007CLookup$007C_$007C(new Stat(0), matchValue_1);
        if (activePatternResult15379 != null) {
            const activePatternResult15380 = $007CLookup$007C_$007C(new Stat(1), matchValue_1);
            if (activePatternResult15380 != null) {
                const activePatternResult15381 = $007CLookup$007C_$007C(new Stat(2), matchValue_1);
                if (activePatternResult15381 != null) {
                    const activePatternResult15382 = $007CLookup$007C_$007C(new Stat(3), matchValue_1);
                    if (activePatternResult15382 != null) {
                        const activePatternResult15383 = $007CLookup$007C_$007C(new Stat(4), matchValue_1);
                        if (activePatternResult15383 != null) {
                            const activePatternResult15384 = $007CLookup$007C_$007C(new Stat(5), matchValue_1);
                            if (activePatternResult15384 != null) {
                                pattern_matching_result = 0;
                                cha = activePatternResult15384;
                                con = activePatternResult15381;
                                dex = activePatternResult15380;
                                int = activePatternResult15382;
                                str = activePatternResult15379;
                                wis = activePatternResult15383;
                            }
                            else {
                                pattern_matching_result = 1;
                            }
                        }
                        else {
                            pattern_matching_result = 1;
                        }
                    }
                    else {
                        pattern_matching_result = 1;
                    }
                }
                else {
                    pattern_matching_result = 1;
                }
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
                const traitSetting = toSetting((elements) => ofSeq(elements, {
                    Compare: (x, y) => compare(x, y),
                }), Universal_rules2e, [new ADND2nd_Trait(0)], ctx, decisions);
                const traits = traitSetting.summary;
                const classes = Array.from(map_2((tupledArg) => {
                    const cl_1 = tupledArg[0];
                    const lst = tupledArg[1];
                    return [cl_1, max(map_2((tuple_1) => tuple_1[1], lst), {
                        Compare: (x_2, y_2) => comparePrimitives(x_2, y_2),
                    })];
                }, groupBy((tuple) => tuple[0], choose((_arg1) => {
                    if (_arg1.tag === 6) {
                        const lvl = _arg1.fields[1] | 0;
                        const cl = _arg1.fields[0];
                        return [cl, lvl];
                    }
                    else {
                        return void 0;
                    }
                }, traits), {
                    Equals: (x_1, y_1) => equals(x_1, y_1),
                    GetHashCode: (x_1) => safeHash(x_1),
                })));
                const isWarrior = exists((_arg2) => {
                    let pattern_matching_result_1;
                    if (_arg2[0].tag === 0) {
                        pattern_matching_result_1 = 0;
                    }
                    else if (_arg2[0].tag === 1) {
                        pattern_matching_result_1 = 0;
                    }
                    else if (_arg2[0].tag === 2) {
                        pattern_matching_result_1 = 0;
                    }
                    else {
                        pattern_matching_result_1 = 1;
                    }
                    switch (pattern_matching_result_1) {
                        case 0: {
                            return true;
                        }
                        case 1: {
                            return false;
                        }
                    }
                }, classes);
                const has = (arg00) => FSharpSet__Contains(traits, arg00);
                const hdMultiplier = defaultArg(tryPick((_arg3) => {
                    if (_arg3.tag === 5) {
                        const n = _arg3.fields[0] | 0;
                        return n;
                    }
                    else {
                        return void 0;
                    }
                }, traits), 1) | 0;
                const hp = choose((_arg4) => {
                    if (_arg4.tag === 6) {
                        const lvl_1 = _arg4.fields[1] | 0;
                        const cl_2 = _arg4.fields[0];
                        return ADND2nd_hpOf(con, isWarrior, hdMultiplier, lvl_1, cl_2);
                    }
                    else {
                        return void 0;
                    }
                }, traits);
                const ac_1 = (fold((e1, e2) => min_1((x_3, y_3) => comparePrimitives(x_3, y_3), e1, e2), 10, map_2((_arg5) => {
                    let pattern_matching_result_2;
                    if (_arg5[0].tag === 1) {
                        pattern_matching_result_2 = 0;
                    }
                    else if (_arg5[0].tag === 2) {
                        pattern_matching_result_2 = 0;
                    }
                    else if (_arg5[0].tag === 4) {
                        pattern_matching_result_2 = 1;
                    }
                    else if (_arg5[0].tag === 8) {
                        pattern_matching_result_2 = 2;
                    }
                    else if (_arg5[0].tag === 6) {
                        pattern_matching_result_2 = 3;
                    }
                    else if (_arg5[0].tag === 5) {
                        pattern_matching_result_2 = 3;
                    }
                    else if (_arg5[0].tag === 9) {
                        pattern_matching_result_2 = 3;
                    }
                    else if (_arg5[0].tag === 7) {
                        pattern_matching_result_2 = 4;
                    }
                    else if (_arg5[0].tag === 3) {
                        pattern_matching_result_2 = 5;
                    }
                    else {
                        pattern_matching_result_2 = 0;
                    }
                    switch (pattern_matching_result_2) {
                        case 0: {
                            return 3;
                        }
                        case 1: {
                            return 3;
                        }
                        case 2: {
                            return 5;
                        }
                        case 3: {
                            return 4;
                        }
                        case 4: {
                            return 8;
                        }
                        case 5: {
                            return 10;
                        }
                    }
                }, classes)) - ADND2nd_dexACBonus(dex)) | 0;
                let attacks;
                const n_1 = fold((e1_1, e2_1) => max_1((x_4, y_4) => comparePrimitives(x_4, y_4), e1_1, e2_1), 1, map_2((_arg6) => {
                    let pattern_matching_result_3, lvl_2;
                    if (_arg6[0].tag === 0) {
                        pattern_matching_result_3 = 0;
                        lvl_2 = _arg6[1];
                    }
                    else if (_arg6[0].tag === 1) {
                        pattern_matching_result_3 = 0;
                        lvl_2 = _arg6[1];
                    }
                    else if (_arg6[0].tag === 2) {
                        pattern_matching_result_3 = 0;
                        lvl_2 = _arg6[1];
                    }
                    else {
                        pattern_matching_result_3 = 1;
                    }
                    switch (pattern_matching_result_3) {
                        case 0: {
                            if (lvl_2 >= 13) {
                                return 3;
                            }
                            else if (lvl_2 >= 7) {
                                return 2;
                            }
                            else {
                                return 1;
                            }
                        }
                        case 1: {
                            return 1;
                        }
                    }
                }, classes)) | 0;
                attacks = (has(new ADND2nd_Trait(10)) ? (n_1 + 1) : n_1);
                const weapon_1 = maxBy((weapon) => weapon.damage, map_2((_arg7) => {
                    let pattern_matching_result_4;
                    if (_arg7[0].tag === 1) {
                        pattern_matching_result_4 = 0;
                    }
                    else if (_arg7[0].tag === 2) {
                        pattern_matching_result_4 = 0;
                    }
                    else if (_arg7[0].tag === 8) {
                        pattern_matching_result_4 = 0;
                    }
                    else if (_arg7[0].tag === 4) {
                        pattern_matching_result_4 = 1;
                    }
                    else if (_arg7[0].tag === 6) {
                        pattern_matching_result_4 = 1;
                    }
                    else if (_arg7[0].tag === 5) {
                        pattern_matching_result_4 = 1;
                    }
                    else if (_arg7[0].tag === 9) {
                        pattern_matching_result_4 = 2;
                    }
                    else if (_arg7[0].tag === 7) {
                        pattern_matching_result_4 = 3;
                    }
                    else if (_arg7[0].tag === 3) {
                        pattern_matching_result_4 = 4;
                    }
                    else {
                        pattern_matching_result_4 = 0;
                    }
                    switch (pattern_matching_result_4) {
                        case 0: {
                            return {
                                damage: RollSpec_create_Z37302880(3, 6),
                                isSword: true,
                                name: "Greatsword",
                            };
                        }
                        case 1: {
                            return {
                                damage: RollSpec_create_4F7761DC(1, 6, 1),
                                isSword: true,
                                name: "Morning star",
                            };
                        }
                        case 2: {
                            return {
                                damage: RollSpec_create_Z37302880(1, 8),
                                isSword: true,
                                name: "Scimitar",
                            };
                        }
                        case 3: {
                            return {
                                damage: RollSpec_create_Z37302880(1, 12),
                                isSword: true,
                                name: "Longsword",
                            };
                        }
                        case 4: {
                            return {
                                damage: RollSpec_create_Z37302880(1, 6),
                                isSword: true,
                                name: "Quarterstaff",
                            };
                        }
                    }
                }, classes), {
                    Compare: (x_5, y_5) => compare(x_5, y_5),
                });
                const toHitBonus = (((fold((e1_2, e2_2) => max_1((x_6, y_6) => comparePrimitives(x_6, y_6), e1_2, e2_2), 0, map_2((_arg8) => {
                    let pattern_matching_result_5, lvl_3, lvl_4, lvl_5;
                    if (_arg8[0].tag === 1) {
                        pattern_matching_result_5 = 0;
                        lvl_3 = _arg8[1];
                    }
                    else if (_arg8[0].tag === 2) {
                        pattern_matching_result_5 = 0;
                        lvl_3 = _arg8[1];
                    }
                    else if (_arg8[0].tag === 4) {
                        pattern_matching_result_5 = 1;
                        lvl_4 = _arg8[1];
                    }
                    else if (_arg8[0].tag === 6) {
                        pattern_matching_result_5 = 1;
                        lvl_4 = _arg8[1];
                    }
                    else if (_arg8[0].tag === 5) {
                        pattern_matching_result_5 = 1;
                        lvl_4 = _arg8[1];
                    }
                    else if (_arg8[0].tag === 9) {
                        pattern_matching_result_5 = 2;
                        lvl_5 = _arg8[1];
                    }
                    else if (_arg8[0].tag === 8) {
                        pattern_matching_result_5 = 2;
                        lvl_5 = _arg8[1];
                    }
                    else if (_arg8[0].tag === 7) {
                        pattern_matching_result_5 = 2;
                        lvl_5 = _arg8[1];
                    }
                    else if (_arg8[0].tag === 3) {
                        pattern_matching_result_5 = 3;
                    }
                    else {
                        pattern_matching_result_5 = 0;
                        lvl_3 = _arg8[1];
                    }
                    switch (pattern_matching_result_5) {
                        case 0: {
                            return (lvl_3 - 1) | 0;
                        }
                        case 1: {
                            return (2 * ((~(~((lvl_4 + 2) / 3))) - 1)) | 0;
                        }
                        case 2: {
                            return ((~(~((lvl_5 + 1) / 2))) - 1) | 0;
                        }
                        case 3: {
                            const lvl_6 = _arg8[1] | 0;
                            return ((~(~((lvl_6 + 2) / 3))) - 1) | 0;
                        }
                    }
                }, classes)) + ADND2nd_strBonus(str, draft.exceptionalStrength)[0]) + (has(new ADND2nd_Trait(10)) ? 1 : 0)) + (weapon_1.isSword ? defaultArg(tryPick((_arg9) => {
                    if (_arg9.tag === 4) {
                        const n_2 = _arg9.fields[0] | 0;
                        return n_2;
                    }
                    else {
                        return void 0;
                    }
                }, traits), 0) : 0)) | 0;
                const damage = RollSpec_op_Addition_Z57C2BA88(RollSpec_op_Addition_Z57C2BA88((source_19 = map_2((_arg10) => {
                    let pattern_matching_result_6;
                    if (_arg10[0].tag === 1) {
                        pattern_matching_result_6 = 0;
                    }
                    else if (_arg10[0].tag === 2) {
                        pattern_matching_result_6 = 0;
                    }
                    else if (_arg10[0].tag === 8) {
                        pattern_matching_result_6 = 0;
                    }
                    else if (_arg10[0].tag === 4) {
                        pattern_matching_result_6 = 1;
                    }
                    else if (_arg10[0].tag === 6) {
                        pattern_matching_result_6 = 1;
                    }
                    else if (_arg10[0].tag === 5) {
                        pattern_matching_result_6 = 1;
                    }
                    else if (_arg10[0].tag === 9) {
                        pattern_matching_result_6 = 2;
                    }
                    else if (_arg10[0].tag === 7) {
                        pattern_matching_result_6 = 3;
                    }
                    else if (_arg10[0].tag === 3) {
                        pattern_matching_result_6 = 4;
                    }
                    else {
                        pattern_matching_result_6 = 0;
                    }
                    switch (pattern_matching_result_6) {
                        case 0: {
                            return RollSpec_create_Z37302880(3, 6);
                        }
                        case 1: {
                            return RollSpec_create_4F7761DC(1, 6, 1);
                        }
                        case 2: {
                            return RollSpec_create_Z37302880(1, 8);
                        }
                        case 3: {
                            return RollSpec_create_Z37302880(1, 12);
                        }
                        case 4: {
                            return RollSpec_create_Z37302880(1, 6);
                        }
                    }
                }, classes), fold((e1_3, e2_3) => max_1((x_7, y_7) => compare(x_7, y_7), e1_3, e2_3), RollSpec_create_Z37302880(0, 0), source_19)), ADND2nd_strBonus(str, draft.exceptionalStrength)[1]), has(new ADND2nd_Trait(10)) ? 2 : 0);
                return new ADND2nd_CharacterSheet(void 0, draft.name, makeOrigin("AD\u0026D"), draft.sex, str, dex, con, int, wis, cha, (isWarrior && (str === 18)) ? draft.exceptionalStrength : (void 0), draft.originalRolls, Array.from(hp), ac_1, attacks, toHitBonus, damage, 0, Array.from(classes), traitSetting, 0);
            }
            case 1: {
                return void 0;
            }
        }
    }
    else {
        return void 0;
    }
}

export function Interaction_$007CCharacterSheet5E$007C_$007C(ctx, makeOrigin, draft) {
    let levels;
    const activePatternResult15404 = Universal_$007CIs5e$007C_$007C(draft.decisions);
    if (activePatternResult15404 != null) {
        const decisions = activePatternResult15404;
        let pattern_matching_result, cha, con, dex, int, str, wis;
        const activePatternResult15398 = $007CLookup$007C_$007C(new Stat(0), ctx);
        if (activePatternResult15398 != null) {
            const activePatternResult15399 = $007CLookup$007C_$007C(new Stat(1), ctx);
            if (activePatternResult15399 != null) {
                const activePatternResult15400 = $007CLookup$007C_$007C(new Stat(2), ctx);
                if (activePatternResult15400 != null) {
                    const activePatternResult15401 = $007CLookup$007C_$007C(new Stat(3), ctx);
                    if (activePatternResult15401 != null) {
                        const activePatternResult15402 = $007CLookup$007C_$007C(new Stat(4), ctx);
                        if (activePatternResult15402 != null) {
                            const activePatternResult15403 = $007CLookup$007C_$007C(new Stat(5), ctx);
                            if (activePatternResult15403 != null) {
                                pattern_matching_result = 0;
                                cha = activePatternResult15403;
                                con = activePatternResult15400;
                                dex = activePatternResult15399;
                                int = activePatternResult15401;
                                str = activePatternResult15398;
                                wis = activePatternResult15402;
                            }
                            else {
                                pattern_matching_result = 1;
                            }
                        }
                        else {
                            pattern_matching_result = 1;
                        }
                    }
                    else {
                        pattern_matching_result = 1;
                    }
                }
                else {
                    pattern_matching_result = 1;
                }
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
                const traitSetting = toSetting((elements) => ofList(elements, {
                    Compare: (x, y) => compare(x, y),
                }), Universal_rules5e, [new DND5e_Trait(0)], ctx, decisions);
                const traits = traitSetting.summary;
                const extraHPPerLevel = defaultArg(tryPick((_arg1) => {
                    if (_arg1.tag === 40) {
                        const n = _arg1.fields[0] | 0;
                        return n;
                    }
                    else {
                        return void 0;
                    }
                }, traits), 0) | 0;
                const hp = choose((_arg2) => {
                    let lvl, cl;
                    let pattern_matching_result_1, cl_1, lvl_1;
                    if (_arg2.tag === 3) {
                        if ((lvl = (_arg2.fields[1] | 0), (cl = _arg2.fields[0], lvl > 0))) {
                            pattern_matching_result_1 = 0;
                            cl_1 = _arg2.fields[0];
                            lvl_1 = _arg2.fields[1];
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
                            return [DND5e_hpOf(lvl_1, cl_1), DND5e_statBonus(con) + extraHPPerLevel];
                        }
                        case 1: {
                            return void 0;
                        }
                    }
                }, traits);
                let patternInput;
                const statBonus = (statValue) => DND5e_statBonus(statValue);
                const toHit = (statBonus(max_1((x_1, y_1) => comparePrimitives(x_1, y_1), str, dex)) + DND5e_proficiencyBonus(traits)) | 0;
                const has = (trait1) => contains(trait1, traits);
                if (has(new DND5e_Trait(36)) && has(new DND5e_Trait(37))) {
                    patternInput = ((str >= dex) ? [16, toHit, RollSpec_create_4F7761DC(2, 6, DND5e_statBonus(str))] : [has(new DND5e_Trait(33)) ? 18 : 16, toHit, RollSpec_create_4F7761DC(1, 8, DND5e_statBonus(dex))]);
                }
                else if (has(new DND5e_Trait(36)) && has(new DND5e_Trait(33))) {
                    patternInput = [18, toHit, RollSpec_create_4F7761DC(2, 6, DND5e_statBonus(str))];
                }
                else if (has(new DND5e_Trait(35))) {
                    const acBonus = min_1((x_2, y_2) => comparePrimitives(x_2, y_2), 2, statBonus(dex)) | 0;
                    if (dex >= str) {
                        patternInput = [(14 + acBonus) + (has(new DND5e_Trait(33)) ? 2 : 0), toHit, RollSpec_create_4F7761DC(1, has(new DND5e_Trait(37)) ? 8 : 6, DND5e_statBonus(dex))];
                    }
                    else {
                        const dmg = (!has(new DND5e_Trait(33))) ? RollSpec_create_4F7761DC(2, 6, statBonus(str)) : RollSpec_create_4F7761DC(1, has(new DND5e_Trait(37)) ? 8 : 6, statBonus(str));
                        patternInput = [(14 + acBonus) + (has(new DND5e_Trait(33)) ? 2 : 0), toHit, dmg];
                    }
                }
                else {
                    const ac = (has(new DND5e_Trait(34)) ? (12 + statBonus(dex)) : (10 + statBonus(dex))) | 0;
                    if (dex >= str) {
                        patternInput = [ac, toHit, RollSpec_create_4F7761DC(1, has(new DND5e_Trait(37)) ? 8 : 6, statBonus(dex))];
                    }
                    else {
                        const dmg_1 = (!has(new DND5e_Trait(33))) ? RollSpec_create_4F7761DC(2, 6, statBonus(str)) : RollSpec_create_4F7761DC(1, has(new DND5e_Trait(37)) ? 8 : 6, statBonus(str));
                        patternInput = [ac, toHit, dmg_1];
                    }
                }
                const toHit_1 = patternInput[1] | 0;
                const damage = patternInput[2];
                const ac_1 = patternInput[0] | 0;
                return (levels = (new Array(0)), new DND5e_CharacterSheet(void 0, draft.name, makeOrigin("D\u0026D 5th Edition"), draft.sex, str, dex, con, int, wis, cha, draft.originalRolls, Array.from(hp), ac_1, toHit_1, damage, 0, levels, traitSetting, 0));
            }
            case 1: {
                return void 0;
            }
        }
    }
    else {
        return void 0;
    }
}

export const Interaction_d = (x) => rand(x);

export function Interaction_inOrder(draft) {
    const matchValue = draft.allocations;
    if ((!equalsWith((x, y) => equalArrays(x, y), matchValue, null)) && (matchValue.length === 6)) {
        const wis = matchValue[4][0] | 0;
        const str = matchValue[0][0] | 0;
        const int = matchValue[3][0] | 0;
        const dex = matchValue[1][0] | 0;
        const con = matchValue[2][0] | 0;
        const cha = matchValue[5][0] | 0;
        const mapSnd = (array) => map_3((tupledArg) => {
            const arg = tupledArg[0] | 0;
            const stat = tupledArg[1];
            return [arg, stat];
        }, array);
        return new Interaction_Draft(draft.name, draft.nationalOrigin, draft.sex, mapSnd([[str, new Stat(0)], [dex, new Stat(1)], [con, new Stat(2)], [int, new Stat(3)], [wis, new Stat(4)], [cha, new Stat(5)]]), draft.exceptionalStrength, draft.originalRolls, new Interaction_Mode(2), draft.decisions);
    }
    else {
        return draft;
    }
}

export function Interaction_roll3d6InOrder(assign) {
    return Interaction_inOrder(assign(toArray(delay(() => collect((matchValue) => singleton(sum(initialize(3, (arg20$0040) => thunk1(Interaction_d, 6, arg20$0040)), {
        GetZero: () => 0,
        Add: (x, y) => (x + y),
    })), rangeDouble(1, 1, 6))))));
}

export function Interaction_roll4d6k3(assign) {
    return assign(toArray(delay(() => collect((matchValue) => singleton(sum(take(3, sortDescending(initialize(4, (arg20$0040) => thunk1(Interaction_d, 6, arg20$0040)), {
        Compare: (x, y) => comparePrimitives(x, y),
    })), {
        GetZero: () => 0,
        Add: (x_1, y_1) => (x_1 + y_1),
    })), rangeDouble(1, 1, 6)))));
}

export function Interaction_rollPHBMethodVI(assign) {
    const inputRecord = assign(toArray(delay(() => collect((matchValue) => singleton(Interaction_d(6)), rangeDouble(1, 1, 7)))));
    return new Interaction_Draft(inputRecord.name, inputRecord.nationalOrigin, inputRecord.sex, inputRecord.allocations, inputRecord.exceptionalStrength, inputRecord.originalRolls, new Interaction_Mode(0, 8, 18), inputRecord.decisions);
}

export function Interaction_darkSunMethodI(assign) {
    return Interaction_inOrder(assign(toArray(delay(() => collect((matchValue) => singleton(4 + sum(initialize(4, (arg20$0040) => thunk1(Interaction_d, 4, arg20$0040)), {
        GetZero: () => 0,
        Add: (x, y) => (x + y),
    })), rangeDouble(1, 1, 6))))));
}

export function Interaction_darkSun6d4(assign) {
    return assign(toArray(delay(() => collect((matchValue) => singleton(sum(take(5, sortDescending(initialize(6, (arg20$0040) => thunk1(Interaction_d, 4, arg20$0040)), {
        Compare: (x, y) => comparePrimitives(x, y),
    })), {
        GetZero: () => 0,
        Add: (x_1, y_1) => (x_1 + y_1),
    })), rangeDouble(1, 1, 6)))));
}

export function Interaction_darkSunMethodV(assign) {
    const inputRecord = assign(toArray(delay(() => collect((matchValue) => singleton(Interaction_d(4)), rangeDouble(1, 1, 10)))));
    return new Interaction_Draft(inputRecord.name, inputRecord.nationalOrigin, inputRecord.sex, inputRecord.allocations, inputRecord.exceptionalStrength, inputRecord.originalRolls, new Interaction_Mode(0, 10, 20), inputRecord.decisions);
}

export function Interaction_pointBuy(points, assign) {
    const blank = assign([points]);
    return new Interaction_Draft(blank.name, blank.nationalOrigin, blank.sex, append(toArray(delay(() => map_2((stat) => [8, stat], Stat_get_All()))), blank.allocations), blank.exceptionalStrength, blank.originalRolls, new Interaction_Mode(3), blank.decisions);
}

export function Interaction_unassign(stat, draft) {
    return new Interaction_Draft(draft.name, draft.nationalOrigin, draft.sex, map_3((_arg1) => {
        let stat$0027, ix;
        let pattern_matching_result, ix_1, stat$0027_1;
        if (_arg1[1] != null) {
            if ((stat$0027 = _arg1[1], (ix = (_arg1[0] | 0), equals(stat$0027, stat)))) {
                pattern_matching_result = 0;
                ix_1 = _arg1[0];
                stat$0027_1 = _arg1[1];
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
                return [ix_1, void 0];
            }
            case 1: {
                const same = _arg1;
                return same;
            }
        }
    }, draft.allocations), draft.exceptionalStrength, draft.originalRolls, draft.mode, draft.decisions);
}

export function Interaction_assign(rollIndex, stat, draft) {
    const replaceStat = (i, unchanged) => {
        let s;
        const unchanged_1 = unchanged;
        const value = unchanged_1[0];
        const currentStat = unchanged_1[1];
        if (i === rollIndex) {
            return [value, stat];
        }
        else {
            let pattern_matching_result;
            if (currentStat != null) {
                if ((s = currentStat, equals(draft.mode, new Interaction_Mode(1)) && equals(stat, s))) {
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
                    return [value, void 0];
                }
                case 1: {
                    return unchanged_1;
                }
            }
        }
    };
    const enforceMaximum = (allocations) => {
        const matchValue = draft.mode;
        switch (matchValue.tag) {
            case 2: {
                return allocations;
            }
            case 0: {
                const min$0027 = matchValue.fields[0] | 0;
                const max$0027 = matchValue.fields[1] | 0;
                const recur = (totalSoFar, ix, _arg1) => {
                    let unchanged_2, rest, value_1, unchanged_4, stat$0027, rest_2;
                    if (!isEmpty(_arg1)) {
                        if ((unchanged_2 = head_2(_arg1), (rest = tail(_arg1), ix === rollIndex))) {
                            const rest_1 = tail(_arg1);
                            const unchanged_3 = head_2(_arg1);
                            return cons(unchanged_3, recur(totalSoFar, ix + 1, rest_1));
                        }
                        else {
                            let pattern_matching_result_1, rest_3, stat$0027_1, unchanged_5, value_2;
                            if (!isEmpty(_arg1)) {
                                if (head_2(_arg1)[1] != null) {
                                    if ((value_1 = (head_2(_arg1)[0] | 0), (unchanged_4 = head_2(_arg1), (stat$0027 = head_2(_arg1)[1], (rest_2 = tail(_arg1), equals(stat$0027, stat)))))) {
                                        pattern_matching_result_1 = 0;
                                        rest_3 = tail(_arg1);
                                        stat$0027_1 = head_2(_arg1)[1];
                                        unchanged_5 = head_2(_arg1);
                                        value_2 = head_2(_arg1)[0];
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
                                    if ((totalSoFar + value_2) <= max$0027) {
                                        return cons(unchanged_5, recur(totalSoFar + value_2, ix + 1, rest_3));
                                    }
                                    else {
                                        return cons([value_2, void 0], recur(totalSoFar, ix + 1, rest_3));
                                    }
                                }
                                case 1: {
                                    if (!isEmpty(_arg1)) {
                                        const unchanged_6 = head_2(_arg1);
                                        const rest_4 = tail(_arg1);
                                        return cons(unchanged_6, recur(totalSoFar, ix + 1, rest_4));
                                    }
                                    else {
                                        throw (new Error("Match failure"));
                                    }
                                }
                            }
                        }
                    }
                    else {
                        return empty_1();
                    }
                };
                return recur(min$0027 + item(rollIndex, allocations)[0], 0, allocations);
            }
            case 3: {
                return shouldntHappen();
            }
            default: {
                return allocations;
            }
        }
    };
    return new Interaction_Draft(draft.name, draft.nationalOrigin, draft.sex, toArray_1(enforceMaximum(ofArray(mapIndexed(replaceStat, draft.allocations)))), draft.exceptionalStrength, draft.originalRolls, draft.mode, draft.decisions);
}

export function Interaction_changePointAllocation(stat, amount, draft) {
    let pointsLeft_6, pointsLeft_3, currentValue;
    if (draft.mode.tag === 3) {
        const $007CFor$007C_$007C = (targetStat, allocs) => tryPick_1((_arg1) => {
            let target, amt;
            if ((target = _arg1[1], (amt = (_arg1[0] | 0), equals(target, targetStat)))) {
                const target_1 = _arg1[1];
                const amt_1 = _arg1[0] | 0;
                return amt_1;
            }
            else {
                return void 0;
            }
        }, allocs);
        const otherAllocations = draft.allocations.filter((_arg2) => {
            let otherStat, n;
            let pattern_matching_result;
            if (_arg2[1] != null) {
                if ((otherStat = _arg2[1], (n = (_arg2[0] | 0), !equals(stat, otherStat)))) {
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
        });
        const between = (min$0027, max$0027, x) => {
            if (compare(min$0027, x) <= 0) {
                return compare(x, max$0027) <= 0;
            }
            else {
                return false;
            }
        };
        const allocate = (pointsLeft, currentBonus) => {
            let pointsLeft_1;
            const costOf = (_arg3) => {
                switch (_arg3) {
                    case 8: {
                        return 0;
                    }
                    case 9: {
                        return 1;
                    }
                    case 10: {
                        return 2;
                    }
                    case 11: {
                        return 3;
                    }
                    case 12: {
                        return 4;
                    }
                    case 13: {
                        return 5;
                    }
                    case 14: {
                        return 7;
                    }
                    case 15: {
                        return 9;
                    }
                    default: {
                        return shouldntHappen() | 0;
                    }
                }
            };
            const deltaCost = (costOf(currentBonus + amount) - costOf(currentBonus)) | 0;
            const matchValue_1 = (pointsLeft - deltaCost) | 0;
            if ((pointsLeft_1 = (matchValue_1 | 0), pointsLeft_1 >= 0)) {
                const pointsLeft_2 = matchValue_1 | 0;
                const newValues = [[pointsLeft_2, void 0], [currentBonus + amount, stat]];
                const lst = append(otherAllocations, newValues);
                return new Interaction_Draft(draft.name, draft.nationalOrigin, draft.sex, lst, draft.exceptionalStrength, draft.originalRolls, draft.mode, draft.decisions);
            }
            else {
                return draft;
            }
        };
        const matchValue_2 = draft.allocations;
        let pattern_matching_result_1, currentValue_1, pointsLeft_4;
        const activePatternResult15467 = $007CFor$007C_$007C(void 0, matchValue_2);
        if (activePatternResult15467 != null) {
            const activePatternResult15468 = $007CFor$007C_$007C(stat, matchValue_2);
            if (activePatternResult15468 != null) {
                if ((pointsLeft_3 = (activePatternResult15467 | 0), (currentValue = (activePatternResult15468 | 0), between(8, 15, currentValue + amount)))) {
                    pattern_matching_result_1 = 0;
                    currentValue_1 = activePatternResult15468;
                    pointsLeft_4 = activePatternResult15467;
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
                return allocate(pointsLeft_4, currentValue_1);
            }
            case 1: {
                let pattern_matching_result_2;
                const activePatternResult15463 = $007CFor$007C_$007C(void 0, matchValue_2);
                if (activePatternResult15463 != null) {
                    const activePatternResult15464 = $007CFor$007C_$007C(stat, matchValue_2);
                    if (activePatternResult15464 != null) {
                        pattern_matching_result_2 = 0;
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
                        return draft;
                    }
                    case 1: {
                        let pattern_matching_result_3, pointsLeft_7;
                        const activePatternResult15460 = $007CFor$007C_$007C(void 0, matchValue_2);
                        if (activePatternResult15460 != null) {
                            if ((pointsLeft_6 = (activePatternResult15460 | 0), between(8, 15, amount))) {
                                pattern_matching_result_3 = 0;
                                pointsLeft_7 = activePatternResult15460;
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
                                return allocate(pointsLeft_7, amount);
                            }
                            case 1: {
                                return draft;
                            }
                        }
                    }
                }
            }
        }
    }
    else {
        return shouldntHappen();
    }
}

export function Interaction_create(traits, method) {
    const sex = chooseRandom([new Sex(0), new Sex(1)]);
    const patternInput = makeName(sex);
    const nationalOrigin = patternInput[0];
    const name = patternInput[1];
    return method((rolls) => (new Interaction_Draft(name, nationalOrigin, sex, map_3((x) => [x, void 0], rolls), Universal_Detail$2__get_isADND(traits) ? rand(100) : (void 0), rolls, new Interaction_Mode(1), traits)));
}

export class View_ChargenMethod extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Roll3d6InOrder", "Roll4d6k3", "RollPHBMethodVI", "DarkSunMethodI", "DarkSun6d4", "DarkSunMethodV", "PointBuyN"];
    }
}

export function View_ChargenMethod$reflection() {
    return union_type("UI.Chargen.View.ChargenMethod", [], View_ChargenMethod, () => [[], [], [], [], [], [], [["Item", int32_type]]]);
}

export class View_MethodInfo extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["MethodInfo"];
    }
}

export function View_MethodInfo$reflection() {
    return union_type("UI.Chargen.View.MethodInfo", [], View_MethodInfo, () => [[["name", string_type], ["Item2", lambda_type(lambda_type(array_type(int32_type), Interaction_Draft$reflection()), Interaction_Draft$reflection())]]]);
}

export function View_ChargenMethod_get_ADND() {
    return ofArray([new View_ChargenMethod(0), new View_ChargenMethod(1), new View_ChargenMethod(2), new View_ChargenMethod(3), new View_ChargenMethod(4), new View_ChargenMethod(5)]);
}

export function View_ChargenMethod_get_DND5e() {
    return ofArray([new View_ChargenMethod(0), new View_ChargenMethod(1), new View_ChargenMethod(6, 27), new View_ChargenMethod(6, 31)]);
}

export function View_ChargenMethod__get_info(this$) {
    let tupledArg;
    switch (this$.tag) {
        case 1: {
            tupledArg = ["4d6 drop lowest", (assign_1) => Interaction_roll4d6k3(assign_1)];
            break;
        }
        case 2: {
            tupledArg = ["7d6, assign to taste", (assign_2) => Interaction_rollPHBMethodVI(assign_2)];
            break;
        }
        case 3: {
            tupledArg = ["Dark Sun default", (assign_3) => Interaction_darkSunMethodI(assign_3)];
            break;
        }
        case 4: {
            tupledArg = ["Dark Sun 6d4 drop lowest", (assign_4) => Interaction_darkSun6d4(assign_4)];
            break;
        }
        case 5: {
            tupledArg = ["Dark Sun Method V", (assign_5) => Interaction_darkSunMethodV(assign_5)];
            break;
        }
        case 6: {
            const n = this$.fields[0] | 0;
            tupledArg = [`Point buy (${n})`, (assign_6) => Interaction_pointBuy(n, assign_6)];
            break;
        }
        default: {
            tupledArg = ["3d6 in order", (assign) => Interaction_roll3d6InOrder(assign)];
        }
    }
    return new View_MethodInfo(0, tupledArg[0], tupledArg[1]);
}

export function View_MethodInfo__get_f(this$) {
    const name = this$.fields[0];
    const f = this$.fields[1];
    return f;
}

export function View_MethodInfo__get_name$0027(this$) {
    const name = this$.fields[0];
    const f = this$.fields[1];
    return name;
}

export class View_Ruleset extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["TSR", "WotC"];
    }
}

export function View_Ruleset$reflection() {
    return union_type("UI.Chargen.View.Ruleset", [], View_Ruleset, () => [[], []]);
}

export class View_Model extends Record {
    constructor(draft, method, editMode, ruleset) {
        super();
        this.draft = draft;
        this.method = method;
        this.editMode = editMode;
        this.ruleset = ruleset;
    }
}

export function View_Model$reflection() {
    return record_type("UI.Chargen.View.Model", [], View_Model, () => [["draft", option_type(Interaction_Draft$reflection())], ["method", View_ChargenMethod$reflection()], ["editMode", View_TextEditMode$reflection()], ["ruleset", View_Ruleset$reflection()]]);
}

export class View_TextEditMode extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["NotEditingText", "EditingName"];
    }
}

export function View_TextEditMode$reflection() {
    return union_type("UI.Chargen.View.TextEditMode", [], View_TextEditMode, () => [[], []]);
}

export class View_ParentMsg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["SaveAndQuit", "BeginAdventuring", "Cancel", "UpdateUrl"];
    }
}

export function View_ParentMsg$reflection() {
    return union_type("UI.Chargen.View.ParentMsg", [], View_ParentMsg, () => [[["Item", Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection())]], [["Item", Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection())]], [], [["suffix", string_type]]]);
}

export class View_Msg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Reroll", "SetMethod", "AssignRoll", "UnassignRolls", "ChangePointAllocation", "SetName", "SetSex", "ToggleADNDTrait", "Toggle5ETrait", "SetEditMode", "SetRuleset"];
    }
}

export function View_Msg$reflection() {
    return union_type("UI.Chargen.View.Msg", [], View_Msg, () => [[], [["Item", View_ChargenMethod$reflection()]], [["ix", int32_type], ["stat", Stat$reflection()]], [["stat", Stat$reflection()]], [["stat", Stat$reflection()], ["amount", int32_type]], [["Item", string_type]], [["Item", Sex$reflection()]], [["head", ADND2nd_Trait$reflection()], ["choiceIx", int32_type], ["decisionIx", int32_type]], [["head", DND5e_Trait$reflection()], ["choiceIx", int32_type], ["decisionIx", int32_type]], [["Item", View_TextEditMode$reflection()]], [["Item", View_Ruleset$reflection()]]]);
}

export function View_init(_arg1) {
    return View_reroll(new View_Model(void 0, head_2(View_ChargenMethod_get_ADND()), new View_TextEditMode(0), new View_Ruleset(0)));
}

export function View_reroll(model) {
    const traits = equals(model.ruleset, new View_Ruleset(0)) ? (new Universal_Detail$2(0, empty())) : (new Universal_Detail$2(1, empty()));
    const char = Interaction_create(traits, View_MethodInfo__get_f(View_ChargenMethod__get_info(model.method)));
    return new View_Model(char, model.method, model.editMode, model.ruleset);
}

export function View_update(cmd, informParent, msg, model) {
    switch (msg.tag) {
        case 1: {
            const m = msg.fields[0];
            return [new View_Model(model.draft, m, model.editMode, model.ruleset), cmd(new View_Msg(0))];
        }
        case 2: {
            const stat = msg.fields[1];
            const ix = msg.fields[0] | 0;
            return [new View_Model(map_4((draft) => Interaction_assign(ix, stat, draft), model.draft), model.method, model.editMode, model.ruleset), empty_1()];
        }
        case 3: {
            const stat_1 = msg.fields[0];
            const matchValue = model.draft;
            let pattern_matching_result;
            if (matchValue != null) {
                if (matchValue.mode.tag === 1) {
                    pattern_matching_result = 0;
                }
                else if (matchValue.mode.tag === 0) {
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
                    return [new View_Model(map_4((draft_1) => Interaction_unassign(stat_1, draft_1), model.draft), model.method, model.editMode, model.ruleset), empty_1()];
                }
                case 1: {
                    return [model, empty_1()];
                }
            }
        }
        case 4: {
            const stat_2 = msg.fields[0];
            const plusOrMinus = msg.fields[1] | 0;
            const draft$0027 = map_4((draft_2) => Interaction_changePointAllocation(stat_2, plusOrMinus, draft_2), model.draft);
            const arg10 = value_96(draft$0027).allocations;
            toConsole(printf("%A"))(arg10);
            return [new View_Model(draft$0027, model.method, model.editMode, model.ruleset), empty_1()];
        }
        case 10: {
            const ruleset = msg.fields[0];
            const msg_1 = new View_Msg(1, equals(ruleset, new View_Ruleset(0)) ? head_2(View_ChargenMethod_get_ADND()) : head_2(View_ChargenMethod_get_DND5e()));
            return [new View_Model(model.draft, model.method, model.editMode, ruleset), Cmd_batch(ofArray([cmd(msg_1), informParent(new View_ParentMsg(3, equals(ruleset, new View_Ruleset(0)) ? "adnd" : "5e"))]))];
        }
        case 5: {
            const name = msg.fields[0];
            return [new View_Model(map_4((draft_3) => (new Interaction_Draft(name, "", draft_3.sex, draft_3.allocations, draft_3.exceptionalStrength, draft_3.originalRolls, draft_3.mode, draft_3.decisions)), model.draft), model.method, model.editMode, model.ruleset), empty_1()];
        }
        case 9: {
            const mode = msg.fields[0];
            return [new View_Model(model.draft, model.method, mode, model.ruleset), empty_1()];
        }
        case 6: {
            const sex = msg.fields[0];
            const setSex = (draft_4) => {
                const patternInput = makeName(sex);
                const nationalOrigin = patternInput[0];
                const name_1 = patternInput[1];
                return new Interaction_Draft(name_1, nationalOrigin, sex, draft_4.allocations, draft_4.exceptionalStrength, draft_4.originalRolls, draft_4.mode, draft_4.decisions);
            };
            return [new View_Model(map_4(setSex, model.draft), model.method, model.editMode, model.ruleset), empty_1()];
        }
        case 8: {
            const head = msg.fields[0];
            const decisionIx = msg.fields[2] | 0;
            const choiceIx = msg.fields[1] | 0;
            const toggle = (draft_5) => (new Interaction_Draft(draft_5.name, draft_5.nationalOrigin, draft_5.sex, draft_5.allocations, draft_5.exceptionalStrength, draft_5.originalRolls, draft_5.mode, Universal_Detail$2__map5e_Z1D9544EA(draft_5.decisions, (instance) => toggleTrait(Universal_rules5e, head, choiceIx, decisionIx, instance))));
            return [new View_Model(map_4(toggle, model.draft), model.method, model.editMode, model.ruleset), empty_1()];
        }
        case 7: {
            const head_1 = msg.fields[0];
            const decisionIx_1 = msg.fields[2] | 0;
            const choiceIx_1 = msg.fields[1] | 0;
            const toggle_1 = (draft_6) => (new Interaction_Draft(draft_6.name, draft_6.nationalOrigin, draft_6.sex, draft_6.allocations, draft_6.exceptionalStrength, draft_6.originalRolls, draft_6.mode, Universal_Detail$2__map2e_Z1FC644CA(draft_6.decisions, (instance_1) => toggleTrait(Universal_rules2e, head_1, choiceIx_1, decisionIx_1, instance_1))));
            return [new View_Model(map_4(toggle_1, model.draft), model.method, model.editMode, model.ruleset), empty_1()];
        }
        default: {
            return [View_reroll(model), empty_1()];
        }
    }
}

export const View_getPercentile = (() => {
    const normalPersonDistribution = toList(delay(() => collect((x) => collect((y) => map_2((z) => ((x + y) + z), rangeDouble(1, 1, 6)), rangeDouble(1, 1, 6)), rangeDouble(1, 1, 6))));
    const lessThanEqualGroups = new Map(toList(delay(() => collect((x_1) => {
        const count = length(filter((stat) => (stat <= x_1), normalPersonDistribution)) | 0;
        return singleton([x_1, count / length_1(normalPersonDistribution)]);
    }, rangeDouble(1, 1, 25)))));
    return (statValue) => ((statValue > count_1(lessThanEqualGroups)) ? 1 : ((statValue > 0) ? getItemFromDict(lessThanEqualGroups, statValue) : 0));
})();

export const View_describeCharacter = (() => {
    const line = (txt) => createElement("div", {
        children: Interop_reactApi.Children.toArray([txt]),
    });
    return (_arg1) => {
        if (_arg1.tag === 1) {
            const char_1 = _arg1.fields[0];
            return toList(delay(() => {
                let matchValue_1, place_1;
                const describe = (_arg1_3) => DND5e_describeTrait(_arg1_3);
                const race_2 = find((trait1) => contains_1(trait1, DND5e_races, {
                    Equals: (x_1, y_1) => equals(x_1, y_1),
                    GetHashCode: (x_1) => safeHash(x_1),
                }), char_1.traits.summary);
                const class$0027_1 = pick((_arg5) => {
                    let pattern_matching_result, cl, trait1_1;
                    if (_arg5.tag === 3) {
                        if (_arg5.fields[1] === 0) {
                            pattern_matching_result = 0;
                            cl = _arg5.fields[0];
                            trait1_1 = _arg5;
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
                            return describe(trait1_1);
                        }
                        case 1: {
                            return void 0;
                        }
                    }
                }, char_1.traits.summary);
                return append_1((matchValue_1 = char_1.origin.nationalOrigin, (matchValue_1 === "") ? singleton(line(`${char_1.sex} ${describe(race_2)} ${class$0027_1} `)) : ((place_1 = matchValue_1, singleton(line(`${char_1.sex} ${describe(race_2)} ${class$0027_1} from ${place_1}`))))), delay(() => append_1(singleton(line(`${char_1.origin.ruleSystem}, ${char_1.origin.statRollMethod}, from level ${char_1.origin.startingLevel}`)), delay(() => append_1(singleton(line("")), delay(() => {
                    const hpTotal_1 = sumBy((tupledArg_2) => {
                        const hpRoll_3 = tupledArg_2[0] | 0;
                        const conBonus_2 = tupledArg_2[1] | 0;
                        return (hpRoll_3 + conBonus_2) | 0;
                    }, char_1.hp, {
                        GetZero: () => 0,
                        Add: (x_2, y_2) => (x_2 + y_2),
                    }) | 0;
                    const hpBreakdown_1 = String_oxfordJoin(ofArray(map_3((_arg6) => {
                        if (_arg6[1] === 0) {
                            const hpRoll_4 = _arg6[0] | 0;
                            return int32ToString(hpRoll_4);
                        }
                        else {
                            const hpRoll_5 = _arg6[0] | 0;
                            const conBonus_3 = _arg6[1] | 0;
                            return toText(interpolate("%P()%+d%P()", [hpRoll_5, conBonus_3]));
                        }
                    }, char_1.hp)));
                    return append_1(singleton(line(`AC: ${char_1.ac}, HP: ${hpTotal_1} (${hpBreakdown_1})`)), delay(() => {
                        const attacks = fold((e1, e2) => max_1((x_3, y_3) => comparePrimitives(x_3, y_3), e1, e2), 1, choose((_arg7) => {
                            if (_arg7.tag === 41) {
                                const n = _arg7.fields[0] | 0;
                                return n + 1;
                            }
                            else {
                                return void 0;
                            }
                        }, char_1.traits.summary)) | 0;
                        return append_1(singleton(line(toText(interpolate("%P()%+d%P() to hit, damage: %P()", [(attacks > 1) ? (`${attacks} attacks, `) : "", char_1.toHit, char_1.damage])))), delay(() => append_1(singleton(line(`XP: ${char_1.xp}`)), delay(() => {
                            const displayFilter_1 = (set$_1) => filter_1((_arg8) => {
                                let r;
                                let pattern_matching_result_1;
                                if (_arg8.tag === 16) {
                                    pattern_matching_result_1 = 0;
                                }
                                else if (_arg8.tag === 3) {
                                    pattern_matching_result_1 = 0;
                                }
                                else if (_arg8.tag === 2) {
                                    pattern_matching_result_1 = 0;
                                }
                                else if (_arg8.tag === 1) {
                                    pattern_matching_result_1 = 0;
                                }
                                else if (_arg8.tag === 17) {
                                    pattern_matching_result_1 = 0;
                                }
                                else if ((r = _arg8, contains_1(r, DND5e_races, {
                                    Equals: (x_4, y_4) => equals(x_4, y_4),
                                    GetHashCode: (x_4) => safeHash(x_4),
                                }))) {
                                    pattern_matching_result_1 = 1;
                                }
                                else {
                                    pattern_matching_result_1 = 2;
                                }
                                switch (pattern_matching_result_1) {
                                    case 0: {
                                        return false;
                                    }
                                    case 1: {
                                        const r_1 = _arg8;
                                        return false;
                                    }
                                    case 2: {
                                        return true;
                                    }
                                }
                            }, set$_1);
                            return append_1(singleton(line(`${String_join("; ", map_2((_arg1_5) => DND5e_describeTrait(_arg1_5), displayFilter_1(char_1.traits.summary)))}`)), delay(() => singleton(line(`${char_1.wealth} gp`))));
                        }))));
                    }));
                }))))));
            }));
        }
        else {
            const char = _arg1.fields[0];
            return toList(delay(() => {
                let matchValue, place;
                const classes$0027 = String_join("/", map_3((tupledArg) => {
                    const class$0027 = tupledArg[0];
                    const lvl = tupledArg[1] | 0;
                    return `${class$0027} ${lvl}`;
                }, char.levels));
                const race_1 = pick((_arg2) => {
                    if (_arg2.tag === 2) {
                        const race = _arg2;
                        return ADND2nd_describeTrait(race);
                    }
                    else {
                        return void 0;
                    }
                }, char.traits.summary);
                return append_1((matchValue = char.origin.nationalOrigin, (matchValue === "") ? singleton(line(`${char.sex} ${race_1} ${classes$0027} `)) : ((place = matchValue, singleton(line(`${char.sex} ${race_1} ${classes$0027} from ${place}`))))), delay(() => append_1(singleton(line(`${char.origin.ruleSystem}, ${char.origin.statRollMethod}, from level ${char.origin.startingLevel}`)), delay(() => append_1(singleton(line("")), delay(() => {
                    const hpTotal = sumBy((tupledArg_1) => {
                        const hpRoll = tupledArg_1[0] | 0;
                        const conBonus = tupledArg_1[1] | 0;
                        return (hpRoll + conBonus) | 0;
                    }, char.hp, {
                        GetZero: () => 0,
                        Add: (x, y) => (x + y),
                    }) | 0;
                    const hpBreakdown = String_oxfordJoin(ofArray(map_3((_arg3) => {
                        if (_arg3[1] === 0) {
                            const hpRoll_1 = _arg3[0] | 0;
                            return int32ToString(hpRoll_1);
                        }
                        else {
                            const hpRoll_2 = _arg3[0] | 0;
                            const conBonus_1 = _arg3[1] | 0;
                            return toText(interpolate("%P()%+d%P()", [hpRoll_2, conBonus_1]));
                        }
                    }, char.hp)));
                    return append_1(singleton(line(`AC: ${char.ac}, HP: ${hpTotal} (${hpBreakdown})`)), delay(() => append_1(singleton(line(`${((char.attacks > 1) ? (`${char.attacks} attacks, `) : "")}THAC0 ${(20 - char.toHitBonus)}, damage: ${char.damage}`)), delay(() => append_1(singleton(line(`XP: ${char.xp}`)), delay(() => {
                        const displayFilter = (set$) => filter_1((_arg4) => {
                            switch (_arg4.tag) {
                                case 1:
                                case 2:
                                case 6:
                                case 3: {
                                    return false;
                                }
                                default: {
                                    return true;
                                }
                            }
                        }, set$);
                        return append_1(singleton(line(`${String_join("; ", map_2((_arg1_2) => ADND2nd_describeTrait(_arg1_2), displayFilter(char.traits.summary)))}`)), delay(() => singleton(line(`${char.wealth} gp`))));
                    }))))));
                }))))));
            }));
        }
    };
})();

export const View_ddprop = prop;

export function View_class$0027(f, className, children) {
    return f(ofArray([["className", className], ["children", Interop_reactApi.Children.toArray(Array.from(children))]]));
}

export function View_autoFocusInput(view_autoFocusInputInputProps) {
    const props = view_autoFocusInputInputProps.props;
    const self = useReact_useRef_1505(void 0);
    useReact_useEffectOnce_3A5B6456(() => {
        self.current.focus();
        self.current.select();
    });
    return createElement("input", createObj(cons(["ref", self], props)));
}

export function View_currentStat(model, dispatch, stat, statValue) {
    let copyOfStruct;
    const matchValue = model.draft;
    let pattern_matching_result;
    if (matchValue != null) {
        if (matchValue.mode.tag === 3) {
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
            const statValue_1 = defaultArg(statValue, 8) | 0;
            return createElement("span", {
                className: join(" ", ["statValue", "stat" + ((copyOfStruct = stat, toString_1(copyOfStruct)))]),
                children: `${stat} ${statValue_1}  `,
                key: `${stat}`,
                children: Interop_reactApi.Children.toArray([`${stat} ${statValue_1} `, createElement("button", {
                    children: " - ",
                    className: "button1",
                    onClick: (_arg1) => {
                        dispatch(new View_Msg(4, stat, -1));
                    },
                }), createElement("button", {
                    children: " + ",
                    className: "button2",
                    onClick: (_arg2) => {
                        dispatch(new View_Msg(4, stat, 1));
                    },
                })]),
            });
        }
        case 1: {
            if (statValue == null) {
                return createElement("div", {
                    className: join(" ", ["statValue", "stat" + toString_1(stat)]),
                    children: Interop_reactApi.Children.toArray([target_2(ofArray([["targetKey", "stats"], ["key", "currentStat" + toString_1(stat)], ["dropData", stat], ["children", singleton_1(createElement("span", {
                        children: `${stat}     `,
                        key: `${stat}`,
                    }))]]))]),
                });
            }
            else {
                const statValue_2 = statValue | 0;
                return createElement("div", {
                    className: join(" ", ["statValue", "stat" + toString_1(stat)]),
                    children: Interop_reactApi.Children.toArray([target_2(ofArray([["targetKey", "stats"], ["dropData", stat], ["children", singleton_1(createElement("span", createObj(toList(delay(() => append_1(singleton(["key", `${stat}`]), delay(() => {
                        let matchValue_1, activePatternResult15638, exStr, exStr_1;
                        return append_1((matchValue_1 = [stat, model.draft], (matchValue_1[0].tag === 0) ? ((matchValue_1[1] != null) ? ((matchValue_1[1].exceptionalStrength != null) ? ((activePatternResult15638 = Universal_$007CIsADND$007C_$007C(matchValue_1[1].decisions), (activePatternResult15638 != null) ? ($007CHasTrait$007C(ADND2nd_rules, new ADND2nd_Trait(3), new ADND2nd_Trait(6, new ADND2nd_CharacterClass(0), 1), activePatternResult15638) ? (((exStr = (matchValue_1[1].exceptionalStrength | 0), equals(model.ruleset, new View_Ruleset(0)) && (statValue_2 === 18))) ? ((exStr_1 = (matchValue_1[1].exceptionalStrength | 0), singleton(["children", `${stat} ${statValue_2} (${exStr_1}) `]))) : singleton(["children", `${stat} ${statValue_2} `])) : singleton(["children", `${stat} ${statValue_2} `])) : singleton(["children", `${stat} ${statValue_2} `]))) : singleton(["children", `${stat} ${statValue_2} `])) : singleton(["children", `${stat} ${statValue_2} `])) : singleton(["children", `${stat} ${statValue_2} `])), delay(() => singleton(["onClick", (_arg3) => {
                            dispatch(new View_Msg(3, stat));
                        }])));
                    })))))))]]))]),
                });
            }
        }
    }
}

export function View_describeStatTextOnly(stat, statValue) {
    const term = (stat.tag === 1) ? "Faster" : ((stat.tag === 2) ? "Tougher" : ((stat.tag === 3) ? "Smarter" : ((stat.tag === 4) ? "Wiser" : ((stat.tag === 5) ? "More charismatic" : "Stronger"))));
    return toText(interpolate("%P() than %0.1f%P()%% of humanity", [term, View_getPercentile(statValue) * 100]));
}

export function View_describe(model, dispatch, stat, statValue) {
    return react.createElement(react.Fragment, {}, ...toList(delay(() => append_1(singleton(View_currentStat(model, dispatch, stat, statValue)), delay(() => {
        if (statValue == null) {
            return empty_2();
        }
        else {
            const statValue_1 = statValue | 0;
            return singleton(createElement("div", {
                className: join(" ", ["statDescription", "stat" + toString_1(stat)]),
                children: Interop_reactApi.Children.toArray([target_2(ofArray([["targetKey", "stats"], ["key", "statDescr" + toString_1(stat)], ["dropData", stat], ["children", singleton_1(createElement("span", {
                    key: `${stat}descr`,
                    children: View_describeStatTextOnly(stat, statValue_1),
                }))]]))]),
            }));
        }
    })))));
}

export class View_ChoiceStatus extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Fixed", "Open", "Resolved"];
    }
}

export function View_ChoiceStatus$reflection() {
    return union_type("UI.Chargen.View.ChoiceStatus", [], View_ChoiceStatus, () => [[], [], []]);
}

export function View_describeChoiceInReact(plainTraitFilter, dispatch, msg, describe, preconditionContext_0, preconditionContext_1, head, choiceIx, choice, decision) {
    let children_4;
    const preconditionContext = [preconditionContext_0, preconditionContext_1];
    const toString = (x) => {
        let copyOfStruct = x;
        return toString_1(copyOfStruct);
    };
    if (choice.options.length === decision.length) {
        return [new View_ChoiceStatus(0), react.createElement(react.Fragment, {}, ...toList(delay(() => collect((matchValue) => {
            const option = matchValue[1];
            const ix = matchValue[0] | 0;
            if (plainTraitFilter(option)) {
                const name = describe(option);
                return singleton(View_class$0027((arg00) => createElement("span", createObj(arg00)), "plainTrait", singleton_1(name)));
            }
            else {
                return empty_2();
            }
        }, mapIndexed((x_1, y) => tuple2(x_1, y), choice.options)))))];
    }
    else if (choice.numberAllowed === decision.length) {
        return [new View_ChoiceStatus(2), react.createElement(react.Fragment, {}, ...toList(delay(() => collect((matchValue_1) => {
            const option_1 = matchValue_1[1];
            const ix_1 = matchValue_1[0] | 0;
            if (contains_2(option_1, decision, {
                Equals: (x_3, y_1) => equals(x_3, y_1),
                GetHashCode: (x_3) => structuralHash(x_3),
            })) {
                const name_3 = describe(option_1);
                return append_1(singleton(createElement("input", {
                    type: "checkbox",
                    ["aria-checked"]: contains_2(option_1, decision, {
                        Equals: (x_4, y_2) => equals(x_4, y_2),
                        GetHashCode: (x_4) => structuralHash(x_4),
                    }),
                    checked: contains_2(option_1, decision, {
                        Equals: (x_5, y_3) => equals(x_5, y_3),
                        GetHashCode: (x_5) => structuralHash(x_5),
                    }),
                    id: name_3,
                    onClick: (_arg1) => {
                        dispatch(msg([head, choiceIx, ix_1]));
                    },
                    readOnly: true,
                })), delay(() => singleton(createElement("label", {
                    htmlFor: name_3,
                    children: name_3,
                }))));
            }
            else {
                return empty_2();
            }
        }, mapIndexed((x_6, y_4) => tuple2(x_6, y_4), choice.options)))))];
    }
    else {
        return [new View_ChoiceStatus(1), (children_4 = singleton_1(View_class$0027((arg00_1) => createElement("section", createObj(arg00_1)), "choice", toList(delay(() => collect((matchValue_2) => {
            let children_2;
            const option_2 = matchValue_2[1];
            const ix_2 = matchValue_2[0] | 0;
            const name_10 = describe(option_2);
            const isValid = (choice.preconditions == null) ? true : value_96(choice.preconditions)([option_2, preconditionContext]);
            return isValid ? singleton((children_2 = ofArray([createElement("input", {
                type: "checkbox",
                ["aria-checked"]: contains_2(option_2, decision, {
                    Equals: (x_8, y_5) => equals(x_8, y_5),
                    GetHashCode: (x_8) => structuralHash(x_8),
                }),
                checked: contains_2(option_2, decision, {
                    Equals: (x_9, y_6) => equals(x_9, y_6),
                    GetHashCode: (x_9) => structuralHash(x_9),
                }),
                id: name_10,
                onClick: (_arg2) => {
                    dispatch(msg([head, choiceIx, ix_2]));
                },
                readOnly: true,
            }), createElement("label", {
                htmlFor: name_10,
                children: name_10,
            })]), createElement("span", {
                children: Interop_reactApi.Children.toArray(Array.from(children_2)),
            }))) : singleton(View_class$0027((arg00_2) => createElement("span", createObj(arg00_2)), "lacksPrereq", ofArray([createElement("input", {
                type: "checkbox",
                ["aria-checked"]: contains_2(option_2, decision, {
                    Equals: (x_10, y_7) => equals(x_10, y_7),
                    GetHashCode: (x_10) => structuralHash(x_10),
                }),
                checked: contains_2(option_2, decision, {
                    Equals: (x_11, y_8) => equals(x_11, y_8),
                    GetHashCode: (x_11) => structuralHash(x_11),
                }),
                id: name_10,
                readOnly: true,
                disabled: true,
                ["aria-disabled"]: true,
            }), createElement("label", {
                htmlFor: name_10,
                children: name_10,
                disabled: true,
                ["aria-disabled"]: true,
            })])));
        }, mapIndexed((x_12, y_9) => tuple2(x_12, y_9), choice.options)))))), createElement("div", {
            children: Interop_reactApi.Children.toArray(Array.from(children_4)),
        }))];
    }
}

export function View_viewCharacter(_arg1) {
    const sheet = _arg1;
    const char = Universal_$007CGenericCharacterSheet$007C(sheet);
    return toList(delay(() => append_1(singleton(View_class$0027((arg00) => createElement("div", createObj(arg00)), "characterHeader", singleton_1(View_class$0027((arg00_1) => createElement("div", createObj(arg00_1)), "title", singleton_1(`${char.name}`))))), delay(() => {
        const describe = (stat, statValue) => ofArray([createElement("span", createObj(toList(delay(() => {
            let copyOfStruct;
            return append_1(singleton(["className", join(" ", ["statValue", "stat" + ((copyOfStruct = stat, toString_1(copyOfStruct)))])]), delay(() => {
                let matchValue, exceptionalStrength, exceptionalStrength_1;
                return append_1((matchValue = char.exceptionalStrength, (matchValue != null) ? (((exceptionalStrength = (matchValue | 0), equals(stat, new Stat(0)))) ? ((exceptionalStrength_1 = (matchValue | 0), singleton(["children", `${stat} ${statValue} (${exceptionalStrength_1}) `]))) : singleton(["children", `${stat} ${statValue}  `])) : singleton(["children", `${stat} ${statValue}  `])), delay(() => singleton(["key", `${stat}`])));
            }));
        })))), createElement("div", {
            className: join(" ", ["statDescription", "stat" + toString_1(stat)]),
            children: Interop_reactApi.Children.toArray([createElement("span", {
                key: `${stat}descr`,
                children: View_describeStatTextOnly(stat, statValue),
            })]),
        })]);
        return append_1(describe(new Stat(0), char.Str), delay(() => append_1(describe(new Stat(1), char.Dex), delay(() => append_1(describe(new Stat(2), char.Con), delay(() => append_1(describe(new Stat(3), char.Int), delay(() => append_1(describe(new Stat(4), char.Wis), delay(() => append_1(describe(new Stat(5), char.Cha), delay(() => append_1(singleton(View_class$0027((arg00_2) => createElement("div", createObj(arg00_2)), "prettyMiddle", empty_1())), delay(() => singleton(View_class$0027((arg00_3) => createElement("div", createObj(arg00_3)), "summary", View_describeCharacter(sheet)))))))))))))))));
    }))));
}

export function View_view(view_viewInputProps) {
    const dispatch = view_viewInputProps.dispatch;
    const control = view_viewInputProps.control;
    const model = view_viewInputProps.model;
    const describe = (stat, statValue) => View_describe(model, dispatch, stat, statValue);
    return View_class$0027((arg00) => createElement("div", createObj(arg00)), "charGen", toList(delay(() => append_1(singleton(View_class$0027((arg00_1) => createElement("div", createObj(arg00_1)), "header", toList(delay(() => append_1((model.ruleset.tag === 1) ? singleton("Create a character for Fifth Edition Dungeons and Dragons!") : singleton("Create a character for Advanced Dungeons and Dragons!"), delay(() => append_1(collect((matchValue_1) => {
        const ruleset = matchValue_1[1];
        const ix = matchValue_1[0] | 0;
        const name_4 = (ruleset.tag === 0) ? "AD\u0026D" : "5th Edition";
        return append_1(singleton(createElement("input", {
            type: "checkbox",
            ["aria-checked"]: equals(model.ruleset, ruleset),
            checked: equals(model.ruleset, ruleset),
            id: name_4,
            onClick: (_arg1) => {
                dispatch(new View_Msg(10, ruleset));
            },
            readOnly: true,
        })), delay(() => singleton(createElement("label", {
            htmlFor: name_4,
            children: name_4,
        }))));
    }, mapIndexed_1((x, y) => tuple2(x, y), ofArray([new View_Ruleset(0), new View_Ruleset(1)]))), delay(() => singleton(View_class$0027((arg00_2) => createElement("div", createObj(arg00_2)), "controls", singleton_1(createElement("button", {
        children: "Cancel",
        onClick: (_arg2) => {
            control(new View_ParentMsg(2));
        },
    })))))))))))), delay(() => {
        const matchValue_2 = model.draft;
        if (matchValue_2 == null) {
            return empty_2();
        }
        else {
            const draft = matchValue_2;
            return append_1(singleton(createElement("section", {
                className: "prettyMiddle",
            })), delay(() => append_1(singleton(View_class$0027((arg00_3) => createElement("div", createObj(arg00_3)), "characterHeader", singleton_1(View_class$0027((arg00_4) => createElement("div", createObj(arg00_4)), "title", toList(delay(() => append_1((model.editMode.tag === 1) ? singleton(createElement(View_autoFocusInput, {
                props: ofArray([["value", draft.name], ["onChange", (ev) => {
                    dispatch(new View_Msg(5, ev.target.value));
                }], ["onKeyDown", (ev_1) => {
                    if (ev_1.code === "Enter") {
                        dispatch(new View_Msg(9, new View_TextEditMode(0)));
                    }
                }], ["onBlur", (ev_2) => {
                    dispatch(new View_Msg(9, new View_TextEditMode(0)));
                }]]),
            })) : singleton(createElement("span", {
                children: draft.name,
                onClick: (arg20$0040) => {
                    thunk1(dispatch, new View_Msg(9, new View_TextEditMode(1)), arg20$0040);
                },
            })), delay(() => ((draft.nationalOrigin !== "") ? singleton(` from ${draft.nationalOrigin}`) : empty_2()))))))))), delay(() => append_1(singleton(View_class$0027((arg00_5) => createElement("div", createObj(arg00_5)), "chooseSex", toList(delay(() => collect((sex) => {
                const id = toString_1(sex);
                return append_1(singleton(createElement("input", {
                    type: "radio",
                    ["aria-checked"]: equals(draft.sex, sex),
                    checked: equals(draft.sex, sex),
                    id: id,
                    onClick: (_arg3) => {
                        dispatch(new View_Msg(6, sex));
                    },
                    readOnly: true,
                })), delay(() => singleton(createElement("label", {
                    htmlFor: id,
                    children: id,
                }))));
            }, [new Sex(0), new Sex(1)]))))), delay(() => {
                let preracialStatMods;
                const allocations = ofArray(choose_1((_arg1_1) => {
                    if (_arg1_1[1] != null) {
                        const value_44 = _arg1_1[0] | 0;
                        const stat_1 = _arg1_1[1];
                        return [stat_1, value_44];
                    }
                    else {
                        return void 0;
                    }
                }, draft.allocations));
                const matchValue_4 = draft.mode;
                if (matchValue_4.tag === 0) {
                    const min = matchValue_4.fields[0] | 0;
                    preracialStatMods = append_2(allocations, map_5((stat_2) => [stat_2, min], Stat_get_All()));
                }
                else {
                    preracialStatMods = allocations;
                }
                const preracialStatAssignments = Interaction_addUpStats(preracialStatMods);
                let statsAndTraits;
                const addStat = (n, _arg2_1) => {
                    if (_arg2_1 == null) {
                        return n;
                    }
                    else {
                        const current = _arg2_1 | 0;
                        return current + n;
                    }
                };
                const matchValue_5 = draft.decisions;
                if (matchValue_5.tag === 0) {
                    const decisions_1 = matchValue_5.fields[0];
                    const preracialTraits_1 = collect_1(Universal_rules2e, [new ADND2nd_Trait(0)], new ADND2nd_PreconditionContext(preracialStatAssignments, empty()), decisions_1);
                    const racialStatMods_1 = choose_2((_arg4) => {
                        if (_arg4.tag === 1) {
                            const stat_5 = _arg4.fields[0];
                            const delta_1 = _arg4.fields[1] | 0;
                            return [stat_5, delta_1];
                        }
                        else {
                            return void 0;
                        }
                    }, preracialTraits_1);
                    const postRacialStatAssignments_1 = fold((map_1, tupledArg_1) => {
                        const stat_6 = tupledArg_1[0];
                        const n_2 = tupledArg_1[1] | 0;
                        return change(stat_6, partialApply(1, addStat, [n_2]), map_1);
                    }, preracialStatAssignments, racialStatMods_1);
                    const ctx_1 = new ADND2nd_PreconditionContext(preracialStatAssignments, postRacialStatAssignments_1);
                    statsAndTraits = (new Universal_Detail$2(0, {
                        ctx: ctx_1,
                        decisions: decisions_1,
                        traits: collect_1(Universal_rules2e, [new ADND2nd_Trait(0)], ctx_1, decisions_1),
                    }));
                }
                else {
                    const decisions = matchValue_5.fields[0];
                    const preracialTraits = collect_1(Universal_rules5e, [new DND5e_Trait(0)], preracialStatAssignments, decisions);
                    const racialStatMods = choose_2((_arg3_1) => {
                        if (_arg3_1.tag === 16) {
                            const stat_3 = _arg3_1.fields[0];
                            const delta = _arg3_1.fields[1] | 0;
                            return [stat_3, delta];
                        }
                        else {
                            return void 0;
                        }
                    }, preracialTraits);
                    const postRacialStatAssignments = fold((map, tupledArg) => {
                        const stat_4 = tupledArg[0];
                        const n_1 = tupledArg[1] | 0;
                        return change(stat_4, partialApply(1, addStat, [n_1]), map);
                    }, preracialStatAssignments, racialStatMods);
                    statsAndTraits = (new Universal_Detail$2(1, {
                        ctx: postRacialStatAssignments,
                        decisions: decisions,
                        traits: collect_1(Universal_rules5e, [new DND5e_Trait(0)], postRacialStatAssignments, decisions),
                    }));
                }
                return append_1(collect((stat_7) => {
                    const matchValue_6 = tryFind(stat_7, Universal_Detail$2__converge_Z191A36BF(statsAndTraits, (d) => d.ctx.postracialStats, (d_1) => d_1.ctx));
                    if (matchValue_6 == null) {
                        return singleton(describe(stat_7, void 0));
                    }
                    else {
                        const v = matchValue_6 | 0;
                        return singleton(describe(stat_7, v));
                    }
                }, Stat_get_All()), delay(() => append_1(singleton(createElement("div", createObj(toList(delay(() => append_1(equals(draft.mode, new Interaction_Mode(2)) ? singleton(["className", join(" ", ["statRolls", "hide"])]) : singleton(["className", "statRolls"]), delay(() => singleton(["children", Interop_reactApi.Children.toArray(Array.from(toList(delay(() => ((draft.mode.tag === 3) ? append_1(singleton(createElement("span", {
                    children: "Points remaining",
                    className: "label",
                })), delay(() => {
                    const total = sumBy((_arg5) => {
                        if (_arg5[1] == null) {
                            const n_3 = _arg5[0] | 0;
                            return n_3 | 0;
                        }
                        else {
                            return 0;
                        }
                    }, draft.allocations, {
                        GetZero: () => 0,
                        Add: (x_1, y_1) => (x_1 + y_1),
                    }) | 0;
                    return singleton(View_class$0027((arg00_6) => createElement("span", createObj(arg00_6)), "roll", singleton_1(createElement("div", {
                        children: int32ToString(total),
                        className: "value",
                    }))));
                })) : append_1(singleton(createElement("span", {
                    children: "Unassigned (drag and drop)",
                    className: "label",
                })), delay(() => collect((matchValue_8) => {
                    const stat_8 = matchValue_8[1][1];
                    const roll = matchValue_8[1][0] | 0;
                    const ix_1 = matchValue_8[0] | 0;
                    return (stat_8 != null) ? singleton(View_class$0027((arg00_7) => createElement("span", createObj(arg00_7)), "roll", singleton_1(createElement("span", {
                        children: "0",
                        className: join(" ", ["hide", "value"]),
                    })))) : singleton(createElement("span", {
                        className: "roll",
                        children: Interop_reactApi.Children.toArray([container(ofArray([["targetKey", "stats"], ["onDrop", (e) => {
                            const matchValue_9 = e.dropData;
                            let pattern_matching_result, stat_9;
                            if (matchValue_9 != null) {
                                if (value_96(matchValue_9) instanceof Stat) {
                                    pattern_matching_result = 0;
                                    stat_9 = value_96(matchValue_9);
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
                                    dispatch(new View_Msg(2, ix_1, stat_9));
                                    break;
                                }
                                case 1: {
                                    break;
                                }
                            }
                        }], ["children", singleton_1(roll)]]))]),
                    }));
                }, mapIndexed((x_2, y_2) => tuple2(x_2, y_2), draft.allocations)))))))))])))))))), delay(() => append_1(singleton(View_class$0027((arg00_8) => createElement("div", createObj(arg00_8)), "rollingMethods", toList(delay(() => append_1(singleton(createElement("button", {
                    children: "Reroll",
                    onClick: (arg20$0040_1) => {
                        thunk1(dispatch, new View_Msg(0), arg20$0040_1);
                    },
                })), delay(() => {
                    const allowedRollingMethods = equals(model.ruleset, new View_Ruleset(0)) ? View_ChargenMethod_get_ADND() : View_ChargenMethod_get_DND5e();
                    return collect((matchValue_10) => {
                        let children_1;
                        const method = matchValue_10[1];
                        const ix_2 = matchValue_10[0] | 0;
                        return singleton((children_1 = ofArray([createElement("input", {
                            type: "radio",
                            ["aria-checked"]: equals(model.method, method),
                            checked: equals(model.method, method),
                            id: View_MethodInfo__get_name$0027(View_ChargenMethod__get_info(method)),
                            onClick: (_arg4_1) => {
                                dispatch(new View_Msg(1, method));
                            },
                            readOnly: true,
                        }), createElement("label", {
                            htmlFor: View_MethodInfo__get_name$0027(View_ChargenMethod__get_info(method)),
                            children: View_MethodInfo__get_name$0027(View_ChargenMethod__get_info(method)),
                        })]), createElement("div", {
                            children: Interop_reactApi.Children.toArray(Array.from(children_1)),
                        })));
                    }, mapIndexed_1((x_3, y_3) => tuple2(x_3, y_3), allowedRollingMethods));
                })))))), delay(() => {
                    const display = (lst) => {
                        const chosen = choose_2((tupledArg_2) => {
                            const pri = tupledArg_2[0];
                            const e_1 = tupledArg_2[1];
                            if (equals(pri, new View_ChoiceStatus(2))) {
                                return e_1;
                            }
                            else {
                                return void 0;
                            }
                        }, lst);
                        const traits = choose_2((tupledArg_3) => {
                            const pri_1 = tupledArg_3[0];
                            const e_2 = tupledArg_3[1];
                            if (equals(pri_1, new View_ChoiceStatus(0))) {
                                return e_2;
                            }
                            else {
                                return void 0;
                            }
                        }, lst);
                        const choice = choose_2((tupledArg_4) => {
                            const pri_2 = tupledArg_4[0];
                            const e_3 = tupledArg_4[1];
                            if (equals(pri_2, new View_ChoiceStatus(1))) {
                                return e_3;
                            }
                            else {
                                return void 0;
                            }
                        }, lst);
                        return toList(delay(() => append_1((length_1(chosen) > 0) ? singleton(View_class$0027((arg00_9) => createElement("div", createObj(arg00_9)), "chosen", chosen)) : empty_2(), delay(() => append_1((length_1(traits) > 0) ? singleton(View_class$0027((arg00_10) => createElement("div", createObj(arg00_10)), "traits", traits)) : empty_2(), delay(() => map_2((element) => element, choice)))))));
                    };
                    const makeOrigin = (s) => (new Origin(s, draft.nationalOrigin, 1, View_MethodInfo__get_name$0027(View_ChargenMethod__get_info(model.method))));
                    if (statsAndTraits.tag === 0) {
                        const d_3 = statsAndTraits.fields[0];
                        const patternInput_1 = [d_3.traits, d_3.ctx, d_3.decisions];
                        const traits_2 = patternInput_1[0];
                        const decisions_3 = patternInput_1[2];
                        const ctx_3 = patternInput_1[1];
                        const roots_5 = singleton_1(new ADND2nd_Trait(0));
                        const rules_1 = ADND2nd_rules;
                        const exceptStatMods_1 = (_arg7) => {
                            if (_arg7.tag === 1) {
                                return false;
                            }
                            else {
                                return true;
                            }
                        };
                        let toReact_1;
                        const arg40$0040_1 = ofSeq(traits_2, {
                            Compare: (x_5, y_5) => compare(x_5, y_5),
                        });
                        toReact_1 = ((tupledArg_9) => View_describeChoiceInReact(exceptStatMods_1, dispatch, (tupledArg_8) => (new View_Msg(7, tupledArg_8[0], tupledArg_8[1], tupledArg_8[2])), (_arg1_3) => ADND2nd_describeTrait(_arg1_3), arg40$0040_1, ctx_3, tupledArg_9[0], tupledArg_9[1], tupledArg_9[2], tupledArg_9[3]));
                        const traitsForDisplay_1 = summarize(toReact_1, rules_1, [new ADND2nd_Trait(0)], ctx_3, decisions_3);
                        return append_1(singleton(View_class$0027((arg00_13) => createElement("div", createObj(arg00_13)), "chooseTraits", toList(delay(() => display(traitsForDisplay_1))))), delay(() => {
                            if (!exists_1((tupledArg_10) => {
                                const pri_4 = tupledArg_10[0];
                                const e_5 = tupledArg_10[1];
                                return equals(pri_4, new View_ChoiceStatus(1));
                            }, traitsForDisplay_1)) {
                                const activePatternResult15800 = Interaction_$007CCharacterSheet2E$007C_$007C(ctx_3, makeOrigin, draft);
                                if (activePatternResult15800 != null) {
                                    const sheet_2 = activePatternResult15800;
                                    return singleton(View_class$0027((arg00_14) => createElement("div", createObj(arg00_14)), "finalize", singleton_1(createElement("button", {
                                        children: "OK",
                                        onClick: (_arg6_1) => {
                                            control(new View_ParentMsg(1, new Universal_Detail$2(0, sheet_2)));
                                        },
                                    }))));
                                }
                                else {
                                    return empty_2();
                                }
                            }
                            else {
                                return empty_2();
                            }
                        }));
                    }
                    else {
                        const d_2 = statsAndTraits.fields[0];
                        const patternInput = [d_2.traits, d_2.ctx, d_2.decisions];
                        const traits_1 = patternInput[0];
                        const decisions_2 = patternInput[2];
                        const ctx_2 = patternInput[1];
                        const roots_4 = singleton_1(new DND5e_Trait(0));
                        const rules = DND5e_rules;
                        const exceptStatMods = (_arg6) => {
                            if (_arg6.tag === 16) {
                                return false;
                            }
                            else {
                                return true;
                            }
                        };
                        let toReact;
                        const arg40$0040 = ofSeq(traits_1, {
                            Compare: (x_4, y_4) => compare(x_4, y_4),
                        });
                        toReact = ((tupledArg_6) => View_describeChoiceInReact(exceptStatMods, dispatch, (tupledArg_5) => (new View_Msg(8, tupledArg_5[0], tupledArg_5[1], tupledArg_5[2])), (_arg1_2) => DND5e_describeTrait(_arg1_2), arg40$0040, ctx_2, tupledArg_6[0], tupledArg_6[1], tupledArg_6[2], tupledArg_6[3]));
                        const traitsForDisplay = summarize(toReact, rules, roots_4, ctx_2, decisions_2);
                        return append_1(singleton(View_class$0027((arg00_11) => createElement("div", createObj(arg00_11)), "chooseTraits", toList(delay(() => display(traitsForDisplay))))), delay(() => {
                            let sheet;
                            let pattern_matching_result_1, sheet_1;
                            const activePatternResult15789 = Interaction_$007CCharacterSheet5E$007C_$007C(ctx_2, makeOrigin, draft);
                            if (activePatternResult15789 != null) {
                                if ((sheet = activePatternResult15789, !exists_1((tupledArg_7) => {
                                    const pri_3 = tupledArg_7[0];
                                    const e_4 = tupledArg_7[1];
                                    return equals(pri_3, new View_ChoiceStatus(1));
                                }, traitsForDisplay))) {
                                    pattern_matching_result_1 = 0;
                                    sheet_1 = activePatternResult15789;
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
                                    return singleton(View_class$0027((arg00_12) => createElement("div", createObj(arg00_12)), "finalize", singleton_1(createElement("button", {
                                        children: "OK",
                                        onClick: (_arg5_1) => {
                                            control(new View_ParentMsg(1, new Universal_Detail$2(1, sheet_1)));
                                        },
                                    }))));
                                }
                                case 1: {
                                    return empty_2();
                                }
                            }
                        }));
                    }
                }))))));
            }))))));
        }
    })))));
}

//# sourceMappingURL=Chargen.fs.js.map
