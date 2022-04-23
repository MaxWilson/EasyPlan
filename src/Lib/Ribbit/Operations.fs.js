import { String_oxfordJoin, chooseRandom, StateMonad_StateBuilder__Zero, shouldntHappen, StateMonad_StateBuilder__Combine_419033D3, StateMonad_get, StateMonad_transform, StateMonad_getF, StateMonad_stateChange, StateMonad_StateBuilder__Return_1505, StateMonad_StateBuilder__Bind_3179, StateMonad_StateBuilder__Delay_Z38F4EA44, $007CLookup$007C_$007C } from "../Common.fs.js";
import { Affordance, State, Scope, BoolProperty_$ctor_Z55EFCE8F, RollsProperty_$ctor_Z721C83C5, NumberProperty_$ctor_Z18115A39, NumberProperty_$ctor_Z721C83C5, RollProperty_$ctor_Z721C83C5, IdProperty_$ctor_Z721C83C5, TextProperty_$ctor_Z721C83C5, IdProperty_$ctor_Z18115A39 } from "./Types.fs.js";
import { compare, safeHash, equals, getEnumerator, partialApply, uncurry } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { defaultArg } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";
import { tryFind, FSharpMap__get_Item, FSharpMap__ContainsKey, add } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { sortBy, sum, sumBy, map, append, empty, singleton, cons, exists } from "../../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { Union } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { union_type } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { RollSpec_create_4F7761DC, RollSpec_create_Z37302880, RollSpec__roll } from "../Character.fs.js";
import { List_groupBy } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Seq2.js";

export function propFail(rowId, propName, state) {
    let activePatternResult42536, activePatternResult42538, personalName;
    const name = (activePatternResult42536 = $007CLookup$007C_$007C(rowId, state.scope.rows), (activePatternResult42536 != null) ? ((activePatternResult42538 = $007CLookup$007C_$007C("PersonalName", activePatternResult42536), (activePatternResult42538 != null) ? ((activePatternResult42538.tag === 2) ? ((personalName = activePatternResult42538.fields[0], personalName)) : (`Unnamed individual (ID = ${rowId})`)) : (`Unnamed individual (ID = ${rowId})`))) : (`Unnamed individual (ID = ${rowId})`));
    throw (new Error(`${propName} should have been set on ${name}`));
}

export function request(rowId, propName, state) {
    let activePatternResult42544, activePatternResult42546, personalName;
    const name = (activePatternResult42544 = $007CLookup$007C_$007C(rowId, state.scope.rows), (activePatternResult42544 != null) ? ((activePatternResult42546 = $007CLookup$007C_$007C("PersonalName", activePatternResult42544), (activePatternResult42546 != null) ? ((activePatternResult42546.tag === 2) ? ((personalName = activePatternResult42546.fields[0], personalName)) : (`Unnamed individual (ID = ${rowId})`)) : (`Unnamed individual (ID = ${rowId})`))) : (`Unnamed individual (ID = ${rowId})`));
    throw (new Error(`${propName} should have been set on ${name}`));
}

export const prototypeP = IdProperty_$ctor_Z18115A39("prototype", 0);

export const personalNameP = TextProperty_$ctor_Z721C83C5("PersonalName");

export const selfP = IdProperty_$ctor_Z721C83C5("UniqueId");

export const hdP = RollProperty_$ctor_Z721C83C5("HitDice");

export const hpP = NumberProperty_$ctor_Z721C83C5("MaxHP");

export const damageTakenP = NumberProperty_$ctor_Z18115A39("DamageTaken", 0);

export const acP = NumberProperty_$ctor_Z721C83C5("AC");

export const toHitP = NumberProperty_$ctor_Z721C83C5("ToHit");

export const numberOfAttacksP = NumberProperty_$ctor_Z18115A39("NumberOfAttacks", 1);

export const weaponDamageP = RollsProperty_$ctor_Z721C83C5("WeaponDamage");

export const isFriendlyP = BoolProperty_$ctor_Z55EFCE8F("IsFriendly", false);

export const currentTargetP = IdProperty_$ctor_Z18115A39("CurrentTarget", 0);

export function getValue(id, property) {
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, property["Domain.Ribbit.Property`1.GetMZ524259A4"](id), uncurry(2, (_arg1) => {
        const value = _arg1;
        return StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, value);
    }))));
}

export function nextId() {
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state) => StateMonad_getF((state_1) => (defaultArg(state_1.scope.biggestIdSoFar, 0) + 1), state), uncurry(2, (_arg1) => {
        const nextId_1 = _arg1 | 0;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_2) => StateMonad_transform((state_3) => (new State(state_3.properties, state_3.kindsOfMonsters, state_3.roster, state_3.categories, new Scope(state_3.scope.rows, nextId_1), state_3.affordances, state_3.openRequests)), state_2), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, nextId_1)));
    }))));
}

export function addKind(name, initialize) {
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, nextId(), uncurry(2, (_arg1) => {
        const nextId_1 = _arg1 | 0;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state) => StateMonad_get(void 0, state), uncurry(2, (_arg2) => {
            const state_1 = _arg2;
            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, partialApply(1, initialize, [nextId_1]), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_2) => StateMonad_transform((state_3) => (new State(state_3.properties, add(name, nextId_1, state_3.kindsOfMonsters), state_3.roster, state_3.categories, state_3.scope, state_3.affordances, state_3.openRequests)), state_2), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange)))));
        }));
    }))));
}

export function addCharacterToRoster(personalName) {
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, nextId(), uncurry(2, (_arg1) => {
        const monsterId = _arg1 | 0;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_1) => StateMonad_transform((state) => (new State(state.properties, state.kindsOfMonsters, add(personalName, monsterId, state.roster), state.categories, state.scope, state.affordances, state.openRequests)), state_1), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, personalNameP["Domain.Ribbit.Property`1.SetM6570C449"](monsterId, personalName), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, selfP["Domain.Ribbit.Property`1.SetM6570C449"](monsterId, monsterId), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, isFriendlyP["Domain.Ribbit.Property`1.SetM6570C449"](monsterId, true), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, monsterId)))))))));
    }))));
}

export function addMonster(kindOfMonster, initialize) {
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, nextId(), uncurry(2, (_arg1) => {
        const monsterId = _arg1 | 0;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state) => StateMonad_getF((st) => [st.kindsOfMonsters, st.categories], state), uncurry(2, (_arg2) => {
            const kinds = _arg2[0];
            const categories = _arg2[1];
            return StateMonad_StateBuilder__Combine_419033D3(StateMonad_stateChange, (!FSharpMap__ContainsKey(kinds, kindOfMonster)) ? ((shouldntHappen(), StateMonad_StateBuilder__Zero(StateMonad_stateChange))) : StateMonad_StateBuilder__Zero(StateMonad_stateChange), StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => {
                let f_1, tupledArg;
                return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (f_1 = ((tupledArg = [monsterId, FSharpMap__get_Item(kinds, kindOfMonster)], (arg10) => prototypeP["Domain.Ribbit.Property`1.Set"](tupledArg[0], tupledArg[1], arg10))), (state_1) => StateMonad_transform(f_1, state_1)), uncurry(2, () => {
                    const makeUnique = (ix_mut) => {
                        makeUnique:
                        while (true) {
                            const ix = ix_mut;
                            const candidateName = `${kindOfMonster} #${ix}`;
                            const matchValue = tryFind(kindOfMonster, categories);
                            if (matchValue != null) {
                                const existing = matchValue;
                                if (exists((arg) => (candidateName === arg[1]), existing)) {
                                    ix_mut = (ix + 1);
                                    continue makeUnique;
                                }
                                else {
                                    return [candidateName, add(kindOfMonster, cons([monsterId, candidateName], existing), categories)];
                                }
                            }
                            else {
                                return [candidateName, add(kindOfMonster, singleton([monsterId, candidateName]), categories)];
                            }
                            break;
                        }
                    };
                    const patternInput = makeUnique(1);
                    const personalName = patternInput[0];
                    const categories$0027 = patternInput[1];
                    return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_3) => StateMonad_transform((state_2) => (new State(state_2.properties, state_2.kindsOfMonsters, add(personalName, monsterId, state_2.roster), categories$0027, state_2.scope, state_2.affordances, state_2.openRequests)), state_3), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, personalNameP["Domain.Ribbit.Property`1.SetM6570C449"](monsterId, personalName), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, selfP["Domain.Ribbit.Property`1.SetM6570C449"](monsterId, monsterId), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, partialApply(1, initialize, [monsterId]), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, personalName)))))))));
                }));
            })));
        }));
    }))));
}

export function defineAffordance(name, action, state) {
    return new State(state.properties, state.kindsOfMonsters, state.roster, state.categories, state.scope, add(name, new Affordance(name, action), state.affordances), state.openRequests);
}

export function act(affordanceName, id, state) {
    const matchValue = tryFind(affordanceName, state.affordances);
    if (matchValue == null) {
        return shouldntHappen();
    }
    else {
        const affordance = matchValue;
        return affordance.action(id, state);
    }
}

export function findTarget(ids, id) {
    return StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state) => StateMonad_getF((arg10) => currentTargetP["Domain.Ribbit.Property`1.Get"](id, arg10), state), uncurry(2, (_arg1) => {
        const currentTarget = _arg1 | 0;
        return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_1) => StateMonad_getF((ribbit) => {
            if (currentTarget > 0) {
                return hpP["Domain.Ribbit.Property`1.Get"](id, ribbit) > damageTakenP["Domain.Ribbit.Property`1.Get"](currentTarget, ribbit);
            }
            else {
                return false;
            }
        }, state_1), uncurry(2, (_arg2) => {
            const isAlive = _arg2;
            return isAlive ? StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, currentTarget) : StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (state_2) => StateMonad_getF((ribbit_1) => {
                const myTeam = isFriendlyP["Domain.Ribbit.Property`1.Get"](id, ribbit_1);
                const candidates = ids.filter((targetId) => {
                    if (isFriendlyP["Domain.Ribbit.Property`1.Get"](targetId, ribbit_1) !== myTeam) {
                        return hpP["Domain.Ribbit.Property`1.Get"](targetId, ribbit_1) > damageTakenP["Domain.Ribbit.Property`1.Get"](targetId, ribbit_1);
                    }
                    else {
                        return false;
                    }
                });
                if (candidates.length > 0) {
                    const choice = chooseRandom(candidates) | 0;
                    return choice;
                }
                else {
                    return void 0;
                }
            }, state_2), uncurry(2, (_arg3) => {
                const newTarget = _arg3;
                if (newTarget == null) {
                    return StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, void 0);
                }
                else {
                    const newTarget_1 = newTarget | 0;
                    return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, currentTargetP["Domain.Ribbit.Property`1.SetM6570C449"](id, newTarget_1), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange, newTarget_1)));
                }
            }));
        }));
    }))));
}

export class Treasure_Currency extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Copper", "Silver", "Electrum", "Gold", "Platinum", "Gems", "Jewelry"];
    }
}

export function Treasure_Currency$reflection() {
    return union_type("Domain.Ribbit.Operations.Treasure.Currency", [], Treasure_Currency, () => [[], [], [], [], [], [], []]);
}

export function Treasure_treasureValue(treasureTypes) {
    let loot = empty();
    const incr = (description, amt) => {
        loot = append(loot, singleton([amt, description]));
    };
    const money = (multiplier, description_1, probability, roll) => {
        if (Math.random() <= probability) {
            incr(description_1, RollSpec__roll(roll) * multiplier);
        }
    };
    const copper = partialApply(1, money, [1, new Treasure_Currency(0), 1]);
    const silver = partialApply(1, money, [1, new Treasure_Currency(1), 1]);
    const electrum = partialApply(1, money, [1, new Treasure_Currency(2), 1]);
    const gold = partialApply(1, money, [1, new Treasure_Currency(3), 1]);
    const platinum = partialApply(1, money, [5, new Treasure_Currency(4), 1]);
    const copper1000 = partialApply(2, money, [1000, new Treasure_Currency(0)]);
    const silver1000 = partialApply(2, money, [1000, new Treasure_Currency(1)]);
    const electrum1000 = partialApply(2, money, [1000, new Treasure_Currency(2)]);
    const gold1000 = partialApply(2, money, [1000, new Treasure_Currency(3)]);
    const platinum100 = partialApply(2, money, [100, new Treasure_Currency(4)]);
    const gems = partialApply(2, money, [1, new Treasure_Currency(5)]);
    const jewelry = partialApply(2, money, [1, new Treasure_Currency(6)]);
    const roll_1 = (n, d) => RollSpec_create_Z37302880(n, d);
    const rollb = (n_1, d_1, b) => RollSpec_create_4F7761DC(n_1, d_1, b);
    const enumerator = getEnumerator(treasureTypes);
    try {
        while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
            const treasureType = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
            switch (treasureType.tag) {
                case 1: {
                    copper1000(0.5)(roll_1(1, 8));
                    silver1000(0.25)(roll_1(1, 6));
                    electrum1000(0.25)(roll_1(1, 4));
                    gold1000(0.25)(roll_1(1, 3));
                    gems(0.3)(roll_1(1, 8));
                    jewelry(0.2)(roll_1(1, 4));
                    break;
                }
                case 2: {
                    copper1000(0.2)(roll_1(1, 12));
                    silver1000(0.3)(roll_1(1, 6));
                    electrum1000(0.1)(roll_1(1, 4));
                    gems(0.25)(roll_1(1, 6));
                    jewelry(0.25)(roll_1(1, 3));
                    break;
                }
                case 3: {
                    copper1000(0.1)(roll_1(1, 8));
                    silver1000(0.15)(roll_1(1, 2));
                    electrum1000(0.15)(roll_1(1, 8));
                    gold1000(0.5)(roll_1(1, 6));
                    gems(0.3)(roll_1(1, 10));
                    jewelry(0.25)(roll_1(1, 6));
                    break;
                }
                case 4: {
                    copper1000(0.05)(roll_1(1, 10));
                    silver1000(0.25)(roll_1(1, 12));
                    electrum1000(0.25)(roll_1(1, 6));
                    gold1000(0.25)(roll_1(1, 8));
                    gems(0.15)(roll_1(1, 12));
                    jewelry(0.1)(roll_1(1, 2));
                    break;
                }
                case 5: {
                    silver1000(0.1)(roll_1(1, 20));
                    electrum1000(0.15)(roll_1(1, 12));
                    gold1000(0.4)(roll_1(1, 10));
                    platinum100(0.35)(roll_1(1, 8));
                    gems(0.2)(roll_1(2, 10));
                    jewelry(0.1)(roll_1(1, 10));
                    break;
                }
                case 6: {
                    gold1000(0.5)(roll_1(10, 4));
                    platinum100(0.5)(roll_1(1, 20));
                    gems(0.3)(roll_1(5, 4));
                    jewelry(0.25)(roll_1(1, 10));
                    break;
                }
                case 7: {
                    copper1000(0.25)(roll_1(5, 4));
                    silver1000(0.4)(roll_1(1, 100));
                    electrum1000(0.4)(roll_1(10, 4));
                    gold1000(0.55)(roll_1(10, 6));
                    platinum100(0.25)(roll_1(5, 10));
                    gems(0.5)(roll_1(1, 100));
                    jewelry(0.5)(roll_1(1, 40));
                    break;
                }
                case 8: {
                    platinum100(0.3)(roll_1(3, 6));
                    gems(0.55)(roll_1(2, 10));
                    jewelry(0.5)(roll_1(1, 12));
                    break;
                }
                case 9: {
                    copper(roll_1(3, 8));
                    break;
                }
                case 10: {
                    silver(roll_1(3, 6));
                    break;
                }
                case 11: {
                    electrum(roll_1(2, 6));
                    break;
                }
                case 12: {
                    gold(roll_1(2, 4));
                    break;
                }
                case 13: {
                    platinum(roll_1(1, 6));
                    break;
                }
                case 14: {
                    copper1000(0.25)(roll_1(1, 4));
                    silver1000(0.2)(roll_1(1, 3));
                    break;
                }
                case 15: {
                    silver1000(0.3)(roll_1(1, 6));
                    electrum1000(0.25)(roll_1(1, 2));
                    break;
                }
                case 16: {
                    gems(0.5)(roll_1(1, 4));
                    break;
                }
                case 17: {
                    gold1000(0.4)(roll_1(2, 4));
                    platinum100(50)(roll_1(10, 6));
                    gems(0.55)(roll_1(4, 8));
                    jewelry(0.45)(roll_1(1, 12));
                    break;
                }
                case 18: {
                    jewelry(1)(roll_1(2, 4));
                    break;
                }
                case 19: {
                    jewelry(1)(roll_1(1, 4));
                    break;
                }
                case 20: {
                    gems(0.9)(roll_1(10, 8));
                    jewelry(0.8)(roll_1(5, 6));
                    break;
                }
                case 21: {
                    break;
                }
                case 22: {
                    gold1000(0.6)(roll_1(5, 6));
                    platinum100(0.15)(roll_1(1, 8));
                    gems(0.6)(roll_1(10, 8));
                    jewelry(0.5)(roll_1(5, 8));
                    break;
                }
                case 23: {
                    break;
                }
                case 24: {
                    gold1000(0.7)(roll_1(2, 6));
                    break;
                }
                case 25: {
                    copper1000(0.3)(roll_1(1, 3));
                    silver1000(0.25)(roll_1(1, 4));
                    electrum1000(0.25)(roll_1(1, 4));
                    gold1000(0.3)(roll_1(1, 4));
                    platinum100(0.3)(roll_1(1, 6));
                    gems(0.55)(roll_1(10, 6));
                    jewelry(0.5)(roll_1(5, 6));
                    break;
                }
                default: {
                    copper1000(0.25)(roll_1(1, 6));
                    silver1000(0.3)(roll_1(1, 6));
                    electrum1000(0.35)(roll_1(1, 6));
                    gold1000(0.4)(roll_1(1, 10));
                    platinum100(0.25)(roll_1(1, 4));
                    gems(0.6)(roll_1(4, 10));
                    jewelry(0.5)(roll_1(3, 10));
                }
            }
        }
    }
    finally {
        enumerator.Dispose();
    }
    const sumsByCurrency = map((tupledArg) => {
        const currency = tupledArg[0];
        const items = tupledArg[1];
        return [currency, sumBy((tuple_1) => tuple_1[0], items, {
            GetZero: () => 0,
            Add: (x_1, y_1) => (x_1 + y_1),
        })];
    }, List_groupBy((tuple) => tuple[1], loot, {
        Equals: (x, y) => equals(x, y),
        GetHashCode: (x) => safeHash(x),
    }));
    const totalValueInCopper = sum(map((_arg1) => {
        if (_arg1[0].tag === 1) {
            const v_1 = _arg1[1] | 0;
            return (10 * v_1) | 0;
        }
        else if (_arg1[0].tag === 3) {
            const v_2 = _arg1[1] | 0;
            return (100 * v_2) | 0;
        }
        else if (_arg1[0].tag === 2) {
            const v_3 = _arg1[1] | 0;
            return (50 * v_3) | 0;
        }
        else if (_arg1[0].tag === 4) {
            const v_4 = _arg1[1] | 0;
            return (500 * v_4) | 0;
        }
        else if (_arg1[0].tag === 5) {
            const v_5 = _arg1[1] | 0;
            return (10000 * v_5) | 0;
        }
        else if (_arg1[0].tag === 6) {
            const v_6 = _arg1[1] | 0;
            return (50000 * v_6) | 0;
        }
        else {
            const v = _arg1[1] | 0;
            return v | 0;
        }
    }, sumsByCurrency), {
        GetZero: () => 0,
        Add: (x_2, y_2) => (x_2 + y_2),
    }) | 0;
    if (totalValueInCopper > 100) {
        const descriptions = String_oxfordJoin(map((_arg2) => {
            const n_2 = _arg2[1] | 0;
            const currency_1 = _arg2[0];
            return `${n_2} ${currency_1}`;
        }, sortBy((tuple_2) => tuple_2[0], sumsByCurrency, {
            Compare: (x_3, y_3) => compare(x_3, y_3),
        })));
        return [(~(~(totalValueInCopper / 100))) * 1, descriptions];
    }
    else {
        return [0, "nothing of value"];
    }
}

//# sourceMappingURL=Operations.fs.js.map
