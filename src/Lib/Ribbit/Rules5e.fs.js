import { RoundResult, FightResult, FlagsProperty$1__Check, TreasureType, FlagsProperty$1__SetAllM, TreasureType$reflection, NumberProperty_$ctor_Z18115A39, FlagsProperty$1_$ctor_Z721C83C5 } from "./Types.fs.js";
import { toString, Record } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { record_type, list_type, int32_type, string_type } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { RollSpec_op_Subtraction_Z2BE01280, RollSpec, DND5e_Trait, RollSpec_create_4F7761DC, RollSpec_create_Z37302880, RollSpec__roll, DND5e_Trait$reflection, RollSpec$reflection } from "../Character.fs.js";
import { Map_values, rand, shouldntHappen, StateMonad_StateBuilder__For_4BCC29DA, StateMonad_StateBuilder__Zero, StateMonad_StateBuilder__Combine_419033D3, StateMonad_getF, StateMonad_transform, StateMonad_stateChange, StateMonad_StateBuilder__Return_1505, StateMonad_StateBuilder__Bind_3179, StateMonad_StateBuilder__Delay_Z38F4EA44 } from "../Common.fs.js";
import { structuralHash, max, comparePrimitives, uncurry } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { isFriendlyP, findTarget, damageTakenP, personalNameP, addMonster, hpP, addKind, weaponDamageP, numberOfAttacksP, toHitP, acP, hdP } from "./Operations.fs.js";
import { ofList } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Set.js";
import { append as append_1, length, item, ofArray, empty, singleton as singleton_1, map } from "../../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { FSharpMap__get_Item, ofList as ofList_1, FSharpMap__ContainsKey } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { rangeDouble } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Range.js";
import { singleton, append, delay, toList } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Seq.js";
import { toConsole } from "../../ShiningSword/fable_modules/fable-library.3.6.2/String.js";
import { equalsWith, sortDescending, map as map_1, sortByDescending } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Array.js";
import { Array_groupBy } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Seq2.js";

export const traitsP = FlagsProperty$1_$ctor_Z721C83C5("Traits");

export const initBonusP = NumberProperty_$ctor_Z18115A39("InitiativeBonus", 0);

export class MonsterKind extends Record {
    constructor(name, numberAppearing, hd, ac, attacks, toHit, weaponDamage, traits, xp, treasureType, lairTreasure) {
        super();
        this.name = name;
        this.numberAppearing = numberAppearing;
        this.hd = hd;
        this.ac = (ac | 0);
        this.attacks = (attacks | 0);
        this.toHit = (toHit | 0);
        this.weaponDamage = weaponDamage;
        this.traits = traits;
        this.xp = (xp | 0);
        this.treasureType = treasureType;
        this.lairTreasure = lairTreasure;
    }
}

export function MonsterKind$reflection() {
    return record_type("Domain.Ribbit.Rules5e.MonsterKind", [], MonsterKind, () => [["name", string_type], ["numberAppearing", RollSpec$reflection()], ["hd", RollSpec$reflection()], ["ac", int32_type], ["attacks", int32_type], ["toHit", int32_type], ["weaponDamage", list_type(RollSpec$reflection())], ["traits", list_type(DND5e_Trait$reflection())], ["xp", int32_type], ["treasureType", list_type(TreasureType$reflection())], ["lairTreasure", list_type(TreasureType$reflection())]]);
}

export function MonsterKind_create_579143A9(name, numberAppearing, hd, ac, attacks, toHit, weaponDamage, traits, xp, treasureType, lairTreasure) {
    return new MonsterKind(name, numberAppearing, hd, ac, attacks, toHit, weaponDamage, traits, xp, treasureType, lairTreasure);
}

export function load(monsterKind) {
    const initialize = (kindId) => StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, hdP["Domain.Ribbit.Property`1.SetM6570C449"](kindId, monsterKind.hd), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, acP["Domain.Ribbit.Property`1.SetM6570C449"](kindId, monsterKind.ac), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, toHitP["Domain.Ribbit.Property`1.SetM6570C449"](kindId, monsterKind.toHit), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, numberOfAttacksP["Domain.Ribbit.Property`1.SetM6570C449"](kindId, monsterKind.attacks), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, weaponDamageP["Domain.Ribbit.Property`1.SetM6570C449"](kindId, monsterKind.weaponDamage), uncurry(2, () => {
        let tupledArg;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (tupledArg = [kindId, ofList(map((value) => toString(value), monsterKind.traits), {
            Compare: (x, y) => comparePrimitives(x, y),
        })], (arg10) => FlagsProperty$1__SetAllM(traitsP, tupledArg[0], tupledArg[1], arg10)), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange)));
    }))))))))))));
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, addKind(monsterKind.name, uncurry(2, initialize)), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange)))));
}

export function create(monsterKind, n) {
    const initialize = (monsterId) => StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state) => StateMonad_transform((state_1) => {
        const tupledArg = [monsterId, RollSpec__roll(hdP["Domain.Ribbit.Property`1.Get"](monsterId, state_1))];
        return hpP["Domain.Ribbit.Property`1.Set"](tupledArg[0], tupledArg[1], state_1);
    }, state), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange)))));
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_2) => StateMonad_getF((state_3) => FSharpMap__ContainsKey(state_3.kindsOfMonsters, monsterKind.name), state_2), uncurry(2, (_arg2) => {
        const alreadyLoaded = _arg2;
        return StateMonad_StateBuilder__Combine_419033D3(StateMonad_stateChange, (!alreadyLoaded) ? StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, load(monsterKind), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange))) : StateMonad_StateBuilder__Zero(StateMonad_stateChange), StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__For_4BCC29DA(StateMonad_stateChange, rangeDouble(1, 1, n), uncurry(2, (_arg4) => {
            const ix = _arg4 | 0;
            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, addMonster(monsterKind.name, uncurry(2, initialize)), uncurry(2, (_arg5) => {
                const personalName = _arg5;
                return StateMonad_StateBuilder__Zero(StateMonad_stateChange);
            }));
        })))));
    }))));
}

export const monsterKinds = ofList_1(map((args) => {
    let monster;
    const tupledArg = args;
    monster = MonsterKind_create_579143A9(tupledArg[0], tupledArg[1], tupledArg[2], tupledArg[3], tupledArg[4], tupledArg[5], tupledArg[6], tupledArg[7], tupledArg[8], tupledArg[9], tupledArg[10]);
    return [monster.name, monster];
}, toList(delay(() => {
    const roll = (n, d) => RollSpec_create_Z37302880(n, d);
    const rollb = (n_1, d_1, b) => RollSpec_create_4F7761DC(n_1, d_1, b);
    return append(singleton(["Jackal", roll(1, 6), roll(1, 6), 12, 1, 1, singleton_1(rollb(1, 4, -1)), singleton_1(new DND5e_Trait(42)), 10, empty(), empty()]), delay(() => append(singleton(["Porcupine", roll(1, 2), roll(1, 4), 13, 1, 2, singleton_1(roll(2, 3)), empty(), 25, empty(), empty()]), delay(() => append(singleton(["Wolf", roll(2, 6), rollb(2, 8, 2), 13, 1, 4, singleton_1(rollb(2, 4, 2)), singleton_1(new DND5e_Trait(42)), 50, empty(), empty()]), delay(() => append(singleton(["Kobold", roll(5, 4), rollb(2, 6, -2), 12, 1, 4, singleton_1(rollb(1, 4, 2)), singleton_1(new DND5e_Trait(42)), 25, singleton_1(new TreasureType(9)), ofArray([new TreasureType(14), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16)])]), delay(() => append(singleton(["Goblin", roll(4, 6), roll(2, 6), 15, 1, 4, singleton_1(rollb(1, 6, 2)), singleton_1(new DND5e_Trait(39)), 50, singleton_1(new TreasureType(10)), singleton_1(new TreasureType(2))]), delay(() => append(singleton(["Guard", roll(2, 10), rollb(2, 8, 2), 18, 1, 3, singleton_1(rollb(1, 8, 1)), empty(), 100, ofArray([new TreasureType(9), new TreasureType(12)]), ofArray([new TreasureType(3), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16)])]), delay(() => append(singleton(["Hobgoblin", roll(2, 10), rollb(2, 8, 2), 18, 1, 3, singleton_1(rollb(1, 8, 1)), singleton_1(new DND5e_Trait(43)), 100, ofArray([new TreasureType(9), new TreasureType(12), new TreasureType(3)]), ofArray([new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16)])]), delay(() => append(singleton(["Black Bear", roll(1, 3), rollb(3, 8, 6), 11, 2, 3, ofArray([rollb(1, 6, 2), rollb(2, 4, 2)]), empty(), 100, empty(), empty()]), delay(() => append(singleton(["Owlbear", new RollSpec(0, 1), rollb(7, 10, 21), 13, 3, 7, ofArray([rollb(1, 10, 5), rollb(2, 8, 5)]), empty(), 700, empty(), singleton_1(new TreasureType(2))]), delay(() => append(singleton(["Hill Giant", roll(1, 12), rollb(10, 12, 40), 13, 2, 8, singleton_1(rollb(3, 8, 5)), empty(), 1800, singleton_1(new TreasureType(3)), empty()]), delay(() => singleton(["Frost Giant", roll(1, 8), rollb(12, 12, 60), 15, 2, 9, singleton_1(rollb(3, 12, 6)), empty(), 3900, singleton_1(new TreasureType(4)), empty()])))))))))))))))))))));
}))));

export function createByName(name, n) {
    return create(FSharpMap__get_Item(monsterKinds, name), n);
}

export function getOk(f, state) {
    const matchValue = StateMonad_getF(f, state);
    if (matchValue[0].tag === 0) {
        const state_1 = matchValue[1];
        return [void 0, state_1];
    }
    else {
        return shouldntHappen("Shouldn\u0027t call getOk unless underlying property is already set");
    }
}

export function attack(ids, id) {
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state) => StateMonad_getF((arg10) => numberOfAttacksP["Domain.Ribbit.Property`1.Get"](id, arg10), state), uncurry(2, (_arg1) => {
        const numberOfAttacks = _arg1 | 0;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_1) => StateMonad_getF((arg10_1) => toHitP["Domain.Ribbit.Property`1.Get"](id, arg10_1), state_1), uncurry(2, (_arg2) => {
            const toHit = _arg2 | 0;
            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_2) => StateMonad_getF((arg10_2) => weaponDamageP["Domain.Ribbit.Property`1.Get"](id, arg10_2), state_2), uncurry(2, (_arg3) => {
                const dmgs = _arg3;
                return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_3) => StateMonad_getF((arg10_3) => personalNameP["Domain.Ribbit.Property`1.Get"](id, arg10_3), state_3), uncurry(2, (_arg4) => {
                    const name = _arg4;
                    let msgs = empty();
                    return StateMonad_StateBuilder__Combine_419033D3(StateMonad_stateChange, StateMonad_StateBuilder__For_4BCC29DA(StateMonad_stateChange, rangeDouble(1, 1, numberOfAttacks), uncurry(2, (_arg5) => {
                        const ix = _arg5 | 0;
                        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_5) => StateMonad_getF((state_4) => (hpP["Domain.Ribbit.Property`1.Get"](id, state_4) > damageTakenP["Domain.Ribbit.Property`1.Get"](id, state_4)), state_5), uncurry(2, (_arg6) => {
                            const isAlive = _arg6;
                            return isAlive ? StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, findTarget(ids, id), uncurry(2, (_arg7) => {
                                const target = _arg7;
                                if (target == null) {
                                    return StateMonad_StateBuilder__Zero(StateMonad_stateChange);
                                }
                                else {
                                    const targetId = target | 0;
                                    return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_6) => StateMonad_getF((arg10_6) => personalNameP["Domain.Ribbit.Property`1.Get"](targetId, arg10_6), state_6), uncurry(2, (_arg8) => {
                                        const targetName = _arg8;
                                        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_7) => StateMonad_getF((arg10_7) => acP["Domain.Ribbit.Property`1.Get"](targetId, arg10_7), state_7), uncurry(2, (_arg9) => {
                                            const ac = _arg9 | 0;
                                            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_8) => StateMonad_getF((ribbit) => {
                                                let tupledArg;
                                                if ((tupledArg = [id, new DND5e_Trait(42)], FlagsProperty$1__Check(traitsP, tupledArg[0], tupledArg[1], ribbit))) {
                                                    const myTeam = isFriendlyP["Domain.Ribbit.Property`1.Get"](id, ribbit);
                                                    return ids.some((otherId) => {
                                                        if ((otherId !== id) && (isFriendlyP["Domain.Ribbit.Property`1.Get"](otherId, ribbit) === myTeam)) {
                                                            return hpP["Domain.Ribbit.Property`1.Get"](otherId, ribbit) > damageTakenP["Domain.Ribbit.Property`1.Get"](otherId, ribbit);
                                                        }
                                                        else {
                                                            return false;
                                                        }
                                                    });
                                                }
                                                else {
                                                    return false;
                                                }
                                            }, state_8), uncurry(2, (_arg10) => {
                                                let n_1, n_2, n_3;
                                                const packTacticsApplies = _arg10;
                                                const hasAdvantage = packTacticsApplies;
                                                toConsole(`${name} has PackTactics? ${packTacticsApplies}`);
                                                const attackRoll = rand(20) | 0;
                                                const secondRoll = rand(20) | 0;
                                                const attackRollDescr = (n) => {
                                                    if (hasAdvantage) {
                                                        return `adv(${attackRoll},${secondRoll})+${toHit} = ${(n + toHit)}`;
                                                    }
                                                    else {
                                                        return `${attackRoll}+${toHit} = ${(n + toHit)}`;
                                                    }
                                                };
                                                const matchValue = (hasAdvantage ? max((x, y) => comparePrimitives(x, y), attackRoll, secondRoll) : attackRoll) | 0;
                                                let pattern_matching_result, n_4;
                                                if (matchValue === 20) {
                                                    if ((n_1 = (matchValue | 0), (n_1 + toHit) >= ac)) {
                                                        pattern_matching_result = 0;
                                                        n_4 = matchValue;
                                                    }
                                                    else if ((n_2 = (matchValue | 0), (n_2 + toHit) >= ac)) {
                                                        pattern_matching_result = 0;
                                                        n_4 = matchValue;
                                                    }
                                                    else {
                                                        pattern_matching_result = 1;
                                                    }
                                                }
                                                else if ((n_3 = (matchValue | 0), (n_3 + toHit) >= ac)) {
                                                    pattern_matching_result = 0;
                                                    n_4 = matchValue;
                                                }
                                                else {
                                                    pattern_matching_result = 1;
                                                }
                                                switch (pattern_matching_result) {
                                                    case 0: {
                                                        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_9) => StateMonad_getF((arg10_13) => damageTakenP["Domain.Ribbit.Property`1.Get"](targetId, arg10_13), state_9), uncurry(2, (_arg11) => {
                                                            let f_9, tupledArg_1;
                                                            const targetDmg = _arg11 | 0;
                                                            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (f_9 = ((tupledArg_1 = [targetId, new DND5e_Trait(26)], (arg10_14) => FlagsProperty$1__Check(traitsP, tupledArg_1[0], tupledArg_1[1], arg10_14))), (state_10) => StateMonad_getF(f_9, state_10)), uncurry(2, (_arg12) => {
                                                                const ham = _arg12;
                                                                const dmg = item(ix % length(dmgs), dmgs);
                                                                const dmg_1 = ham ? RollSpec_op_Subtraction_Z2BE01280(dmg, new RollSpec(0, 3)) : dmg;
                                                                const damage = max((x_1, y_1) => comparePrimitives(x_1, y_1), 0, RollSpec__roll(dmg_1)) | 0;
                                                                return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, damageTakenP["Domain.Ribbit.Property`1.SetM6570C449"](targetId, targetDmg + damage), uncurry(2, () => {
                                                                    msgs = append_1(msgs, singleton_1(`${name} hits ${targetName} for ${damage} points of damage! [Attack roll: ${attackRollDescr(n_4)}, Damage: ${dmg_1} = ${damage}]`));
                                                                    return StateMonad_StateBuilder__Zero(StateMonad_stateChange);
                                                                }));
                                                            }));
                                                        }));
                                                    }
                                                    case 1: {
                                                        const n_5 = matchValue | 0;
                                                        msgs = append_1(msgs, singleton_1(`${name} misses ${targetName}. [Attack roll: ${attackRollDescr(n_5)}]`));
                                                        return StateMonad_StateBuilder__Zero(StateMonad_stateChange);
                                                    }
                                                }
                                            }));
                                        }));
                                    }));
                                }
                            })) : StateMonad_StateBuilder__Zero(StateMonad_stateChange);
                        }));
                    })), StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, msgs))));
                }));
            }));
        }));
    }))));
}

export const fightLogic = StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state) => StateMonad_getF((ribbit) => sortByDescending((tuple) => tuple[1], map_1((id) => [id, rand(20) + initBonusP["Domain.Ribbit.Property`1.Get"](id, ribbit)], Int32Array.from(Map_values(ribbit.roster))), {
    Compare: (x, y) => comparePrimitives(x, y),
}), state), uncurry(2, (_arg1) => {
    const initiativeOrder = _arg1;
    const ids = map_1((tuple_1) => tuple_1[0], initiativeOrder, Int32Array);
    let msgs = empty();
    return StateMonad_StateBuilder__Combine_419033D3(StateMonad_stateChange, StateMonad_StateBuilder__For_4BCC29DA(StateMonad_stateChange, initiativeOrder, uncurry(2, (_arg2) => {
        const init = _arg2[1] | 0;
        const id_1 = _arg2[0] | 0;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, attack(ids, id_1), uncurry(2, (_arg3) => {
            const msgs$0027 = _arg3;
            msgs = append_1(msgs, msgs$0027);
            return StateMonad_StateBuilder__Zero(StateMonad_stateChange);
        }));
    })), StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_2) => StateMonad_getF((state_1) => sortDescending(map_1((tuple_2) => tuple_2[0], Array_groupBy((id_3) => isFriendlyP["Domain.Ribbit.Property`1.Get"](id_3, state_1), ids.filter((id_2) => (hpP["Domain.Ribbit.Property`1.Get"](id_2, state_1) > damageTakenP["Domain.Ribbit.Property`1.Get"](id_2, state_1))), {
        Equals: (x_1, y_1) => (x_1 === y_1),
        GetHashCode: (x_1) => structuralHash(x_1),
    })), {
        Compare: (x_2, y_2) => comparePrimitives(x_2, y_2),
    }), state_2), uncurry(2, (_arg4) => {
        const factions = _arg4;
        const outcome = ((!equalsWith((x_3, y_3) => (x_3 === y_3), factions, null)) && (factions.length === 1)) ? (factions[0] ? (new FightResult(0)) : (new FightResult(1))) : (((!equalsWith((x_4, y_4) => (x_4 === y_4), factions, null)) && (factions.length === 2)) ? (factions[0] ? (factions[1] ? (new FightResult(1)) : (new FightResult(2))) : (new FightResult(1))) : (new FightResult(1)));
        return StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, [outcome, msgs]);
    })))));
}))));

export function fightUntilFixedPoint(ribbit) {
    const patternInput = fightLogic(ribbit);
    const ribbit_1 = patternInput[1];
    const outcome = patternInput[0][0];
    const msg = patternInput[0][1];
    return new RoundResult(outcome, msg, ribbit_1);
}

//# sourceMappingURL=Rules5e.fs.js.map
