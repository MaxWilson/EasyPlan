import { RoundResult, FightResult, TreasureType, FlagsProperty$1__SetAllM, TreasureType$reflection, FlagsProperty$1_$ctor_Z721C83C5 } from "./Types.fs.js";
import { toString, Record } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { record_type, list_type, int32_type, string_type } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { RollSpec_op_Addition_Z2BE01280, RollSpec, RollSpec_create_4F7761DC, RollSpec_create_Z37302880, RollSpec__roll, ADND2nd_Trait$reflection, RollSpec$reflection } from "../Character.fs.js";
import { Map_values, rand, StateMonad_StateBuilder__For_4BCC29DA, StateMonad_StateBuilder__Zero, StateMonad_StateBuilder__Combine_419033D3, StateMonad_getF, StateMonad_stateChange, StateMonad_StateBuilder__Return_1505, StateMonad_transform, StateMonad_StateBuilder__Bind_3179, StateMonad_StateBuilder__Delay_Z38F4EA44 } from "../Common.fs.js";
import { structuralHash, max, comparePrimitives, uncurry } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { isFriendlyP, findTarget, damageTakenP, personalNameP, addMonster, hpP, addKind, weaponDamageP, numberOfAttacksP, toHitP, acP, hdP } from "./Operations.fs.js";
import { ofList } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Set.js";
import { append as append_1, length, item, ofArray, empty, singleton as singleton_1, map } from "../../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { FSharpMap__get_Item, ofList as ofList_1, FSharpMap__ContainsKey } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { rangeDouble } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Range.js";
import { singleton, append, delay, toList } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Seq.js";
import { equalsWith, sortDescending, map as map_1, sortBy } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Array.js";
import { Array_groupBy } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Seq2.js";

export const traitsP = FlagsProperty$1_$ctor_Z721C83C5("Traits");

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
    return record_type("Domain.Ribbit.Rules2e.MonsterKind", [], MonsterKind, () => [["name", string_type], ["numberAppearing", RollSpec$reflection()], ["hd", RollSpec$reflection()], ["ac", int32_type], ["attacks", int32_type], ["toHit", int32_type], ["weaponDamage", list_type(RollSpec$reflection())], ["traits", list_type(ADND2nd_Trait$reflection())], ["xp", int32_type], ["treasureType", list_type(TreasureType$reflection())], ["lairTreasure", list_type(TreasureType$reflection())]]);
}

export function MonsterKind_create_Z39F713A0(name, numberAppearing, hd, ac, attacks, toHit, weaponDamage, traits, xp, treasureType, lairTreasure) {
    return new MonsterKind(name, numberAppearing, hd, ac, attacks, toHit, weaponDamage, traits, xp, treasureType, lairTreasure);
}

export function load(monsterKind) {
    const initialize = (kindId) => StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => {
        let f, tupledArg;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (f = ((tupledArg = [kindId, monsterKind.hd], (arg10) => hdP["Domain.Ribbit.Property`1.Set"](tupledArg[0], tupledArg[1], arg10))), (state) => StateMonad_transform(f, state)), uncurry(2, () => {
            let f_1, tupledArg_1;
            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (f_1 = ((tupledArg_1 = [kindId, monsterKind.ac], (arg10_1) => acP["Domain.Ribbit.Property`1.Set"](tupledArg_1[0], tupledArg_1[1], arg10_1))), (state_1) => StateMonad_transform(f_1, state_1)), uncurry(2, () => {
                let f_2, tupledArg_2;
                return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (f_2 = ((tupledArg_2 = [kindId, monsterKind.toHit], (arg10_2) => toHitP["Domain.Ribbit.Property`1.Set"](tupledArg_2[0], tupledArg_2[1], arg10_2))), (state_2) => StateMonad_transform(f_2, state_2)), uncurry(2, () => {
                    let f_3, tupledArg_3;
                    return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (f_3 = ((tupledArg_3 = [kindId, monsterKind.attacks], (arg10_3) => numberOfAttacksP["Domain.Ribbit.Property`1.Set"](tupledArg_3[0], tupledArg_3[1], arg10_3))), (state_3) => StateMonad_transform(f_3, state_3)), uncurry(2, () => {
                        let f_4, tupledArg_4;
                        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (f_4 = ((tupledArg_4 = [kindId, monsterKind.weaponDamage], (arg10_4) => weaponDamageP["Domain.Ribbit.Property`1.Set"](tupledArg_4[0], tupledArg_4[1], arg10_4))), (state_4) => StateMonad_transform(f_4, state_4)), uncurry(2, () => {
                            let tupledArg_5;
                            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (tupledArg_5 = [kindId, ofList(map((value) => toString(value), monsterKind.traits), {
                                Compare: (x, y) => comparePrimitives(x, y),
                            })], (arg10_5) => FlagsProperty$1__SetAllM(traitsP, tupledArg_5[0], tupledArg_5[1], arg10_5)), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange)));
                        }));
                    }));
                }));
            }));
        }));
    }));
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, addKind(monsterKind.name, uncurry(2, initialize)), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange)))));
}

export function create(monsterKind, n) {
    const initialize = (monsterId) => StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state) => StateMonad_transform((state_1) => {
        const tupledArg = [monsterId, max((x, y) => comparePrimitives(x, y), 1, RollSpec__roll(hdP["Domain.Ribbit.Property`1.Get"](monsterId, state_1)))];
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
    monster = MonsterKind_create_Z39F713A0(tupledArg[0], tupledArg[1], tupledArg[2], tupledArg[3], tupledArg[4], tupledArg[5], tupledArg[6], tupledArg[7], tupledArg[8], tupledArg[9], tupledArg[10]);
    return [monster.name, monster];
}, toList(delay(() => {
    const roll = (n, d) => RollSpec_create_Z37302880(n, d);
    const rollb = (n_1, d_1, b) => RollSpec_create_4F7761DC(n_1, d_1, b);
    return append(singleton(["Jackal", roll(1, 6), roll(1, 4), 7, 1, 0, singleton_1(roll(1, 2)), empty(), 7, empty(), empty()]), delay(() => append(singleton(["Porcupine", roll(1, 2), roll(1, 4), 6, 1, 0, singleton_1(roll(1, 3)), empty(), 15, empty(), empty()]), delay(() => append(singleton(["Wolf", roll(2, 6), roll(3, 8), 7, 1, 2, singleton_1(rollb(1, 4, 1)), empty(), 120, empty(), empty()]), delay(() => append(singleton(["Kobold", roll(5, 4), rollb(1, 8, -1), 7, 1, 0, singleton_1(roll(1, 6)), empty(), 7, singleton_1(new TreasureType(9)), ofArray([new TreasureType(14), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16)])]), delay(() => append(singleton(["Goblin", roll(4, 6), rollb(1, 8, -1), 6, 1, 0, singleton_1(roll(1, 6)), empty(), 15, singleton_1(new TreasureType(10)), singleton_1(new TreasureType(2))]), delay(() => append(singleton(["Guard", roll(2, 10), rollb(1, 8, 1), 5, 1, 1, singleton_1(roll(2, 4)), empty(), 35, ofArray([new TreasureType(9), new TreasureType(12), new TreasureType(3)]), ofArray([new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16)])]), delay(() => append(singleton(["Hobgoblin", roll(2, 10), rollb(1, 8, 1), 5, 1, 1, singleton_1(roll(2, 4)), empty(), 35, ofArray([new TreasureType(9), new TreasureType(12)]), ofArray([new TreasureType(3), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16), new TreasureType(16)])]), delay(() => append(singleton(["Black Bear", roll(1, 3), rollb(3, 8, 3), 7, 2, 3, ofArray([roll(2, 3), roll(1, 6)]), empty(), 175, empty(), empty()]), delay(() => append(singleton(["Owlbear", new RollSpec(0, 1), rollb(5, 8, 2), 5, 3, 5, ofArray([roll(1, 6), roll(1, 6), roll(2, 6)]), empty(), 420, empty(), singleton_1(new TreasureType(2))]), delay(() => append(singleton(["Hill Giant", roll(1, 12), RollSpec_op_Addition_Z2BE01280(roll(12, 8), roll(1, 2)), 3, 1, 11, singleton_1(rollb(2, 6, 7)), empty(), 3000, singleton_1(new TreasureType(3)), empty()]), delay(() => singleton(["Frost Giant", roll(1, 8), RollSpec_op_Addition_Z2BE01280(roll(15, 4), roll(1, 4)), 0, 1, 15, singleton_1(rollb(2, 8, 9)), empty(), 7000, singleton_1(new TreasureType(4)), empty()])))))))))))))))))))));
}))));

export function createByName(name, n) {
    return create(FSharpMap__get_Item(monsterKinds, name), n);
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
                                            let n, n_1, n_2;
                                            const ac = _arg9 | 0;
                                            const matchValue = rand(20) | 0;
                                            let pattern_matching_result, n_3;
                                            if (matchValue === 20) {
                                                if ((n = (matchValue | 0), ((n + toHit) + ac) >= 20)) {
                                                    pattern_matching_result = 0;
                                                    n_3 = matchValue;
                                                }
                                                else if ((n_1 = (matchValue | 0), ((n_1 + toHit) + ac) >= 20)) {
                                                    pattern_matching_result = 0;
                                                    n_3 = matchValue;
                                                }
                                                else {
                                                    pattern_matching_result = 1;
                                                }
                                            }
                                            else if ((n_2 = (matchValue | 0), ((n_2 + toHit) + ac) >= 20)) {
                                                pattern_matching_result = 0;
                                                n_3 = matchValue;
                                            }
                                            else {
                                                pattern_matching_result = 1;
                                            }
                                            switch (pattern_matching_result) {
                                                case 0: {
                                                    return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_8) => StateMonad_getF((arg10_8) => damageTakenP["Domain.Ribbit.Property`1.Get"](targetId, arg10_8), state_8), uncurry(2, (_arg10) => {
                                                        const targetDmg = _arg10 | 0;
                                                        const dmg = item(ix % length(dmgs), dmgs);
                                                        const damage = max((x, y) => comparePrimitives(x, y), 0, RollSpec__roll(dmg)) | 0;
                                                        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, damageTakenP["Domain.Ribbit.Property`1.SetM6570C449"](targetId, targetDmg + damage), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_9) => StateMonad_getF((arg10_9) => hpP["Domain.Ribbit.Property`1.Get"](targetId, arg10_9), state_9), uncurry(2, (_arg12) => {
                                                            const targetHp = _arg12 | 0;
                                                            const killMsg = ((targetDmg + damage) >= targetHp) ? ", a fatal blow" : "";
                                                            msgs = append_1(msgs, singleton_1(`${name} hits ${targetName} for ${damage} points of damage${killMsg}! [Attack roll: ${n_3}, Damage: ${dmg} = ${damage}]`));
                                                            return StateMonad_StateBuilder__Zero(StateMonad_stateChange);
                                                        }))));
                                                    }));
                                                }
                                                case 1: {
                                                    const n_4 = matchValue | 0;
                                                    msgs = append_1(msgs, singleton_1(`${name} misses ${targetName}. [Attack roll: ${n_4}]`));
                                                    return StateMonad_StateBuilder__Zero(StateMonad_stateChange);
                                                }
                                            }
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

export const fightLogic = StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_1) => StateMonad_getF((state) => Int32Array.from(Map_values(state.roster)), state_1), uncurry(2, (_arg1) => {
    const ids = _arg1;
    const initiativeOrder = sortBy((tuple) => tuple[1], map_1((id) => [id, rand(10)], ids), {
        Compare: (x, y) => comparePrimitives(x, y),
    });
    let msgs = empty();
    return StateMonad_StateBuilder__Combine_419033D3(StateMonad_stateChange, StateMonad_StateBuilder__For_4BCC29DA(StateMonad_stateChange, initiativeOrder, uncurry(2, (_arg2) => {
        const init = _arg2[1] | 0;
        const id_1 = _arg2[0] | 0;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, attack(ids, id_1), uncurry(2, (_arg3) => {
            const msgs$0027 = _arg3;
            msgs = append_1(msgs, msgs$0027);
            return StateMonad_StateBuilder__Zero(StateMonad_stateChange);
        }));
    })), StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_3) => StateMonad_getF((state_2) => sortDescending(map_1((tuple_1) => tuple_1[0], Array_groupBy((id_3) => isFriendlyP["Domain.Ribbit.Property`1.Get"](id_3, state_2), ids.filter((id_2) => (hpP["Domain.Ribbit.Property`1.Get"](id_2, state_2) > damageTakenP["Domain.Ribbit.Property`1.Get"](id_2, state_2))), {
        Equals: (x_1, y_1) => (x_1 === y_1),
        GetHashCode: (x_1) => structuralHash(x_1),
    })), {
        Compare: (x_2, y_2) => comparePrimitives(x_2, y_2),
    }), state_3), uncurry(2, (_arg4) => {
        const factions = _arg4;
        const outcome = ((!equalsWith((x_3, y_3) => (x_3 === y_3), factions, null)) && (factions.length === 1)) ? (factions[0] ? (new FightResult(0)) : (new FightResult(1))) : (((!equalsWith((x_4, y_4) => (x_4 === y_4), factions, null)) && (factions.length === 2)) ? (factions[0] ? (factions[1] ? (new FightResult(1)) : (new FightResult(2))) : (new FightResult(1))) : (new FightResult(1)));
        return StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, [outcome, msgs]);
    })))));
}))));

export function fightOneRound(ribbit) {
    const patternInput = fightLogic(ribbit);
    const ribbit_1 = patternInput[1];
    const outcome = patternInput[0][0];
    const msg = patternInput[0][1];
    return new RoundResult(outcome, msg, ribbit_1);
}

//# sourceMappingURL=Rules2e.fs.js.map
