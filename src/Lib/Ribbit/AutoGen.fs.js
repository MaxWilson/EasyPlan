import { Draft_DraftSheet, Creature, CharSheet, StatBlock, Character_CharacterSheet, Character_Stats, Character_Subclass, Character_FightingStyle, Character_Class, Character_Race, Character_HumanType, Character_DwarfRace, Character_ElfRace, Character_Skill, Character_Feat, Character_Sex } from "./Model.fs.js";
import { Lens$2_create } from "../Optics.fs.js";

export function Sex_toString(x) {
    switch (x.tag) {
        case 1: {
            return "Female";
        }
        case 2: {
            return "Neither";
        }
        default: {
            return "Male";
        }
    }
}

export function Sex_fromString(x) {
    switch (x) {
        case "Male": {
            return new Character_Sex(0);
        }
        case "Female": {
            return new Character_Sex(1);
        }
        case "Neither": {
            return new Character_Sex(2);
        }
        default: {
            return void 0;
        }
    }
}

export function Sex_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        default: {
            return 0;
        }
    }
}

export function Sex_isMale(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function Sex_isFemale(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function Sex_isNeither(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function Feat_toString(x) {
    switch (x.tag) {
        case 1: {
            return "CrossbowExpert";
        }
        case 2: {
            return "HeavyArmorMaster";
        }
        case 3: {
            return "GreatWeaponMaster";
        }
        default: {
            return "Sharpshooter";
        }
    }
}

export function Feat_fromString(x) {
    switch (x) {
        case "Sharpshooter": {
            return new Character_Feat(0);
        }
        case "CrossbowExpert": {
            return new Character_Feat(1);
        }
        case "HeavyArmorMaster": {
            return new Character_Feat(2);
        }
        case "GreatWeaponMaster": {
            return new Character_Feat(3);
        }
        default: {
            return void 0;
        }
    }
}

export function Feat_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        case 3: {
            return 3;
        }
        default: {
            return 0;
        }
    }
}

export function Feat_isSharpshooter(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function Feat_isCrossbowExpert(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function Feat_isHeavyArmorMaster(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function Feat_isGreatWeaponMaster(x) {
    if (x.tag === 3) {
        return true;
    }
    else {
        return false;
    }
}

export function Skill_toString(x) {
    switch (x.tag) {
        case 1: {
            return "Stealth";
        }
        case 2: {
            return "Perception";
        }
        case 3: {
            return "Insight";
        }
        default: {
            return "Athletics";
        }
    }
}

export function Skill_fromString(x) {
    switch (x) {
        case "Athletics": {
            return new Character_Skill(0);
        }
        case "Stealth": {
            return new Character_Skill(1);
        }
        case "Perception": {
            return new Character_Skill(2);
        }
        case "Insight": {
            return new Character_Skill(3);
        }
        default: {
            return void 0;
        }
    }
}

export function Skill_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        case 3: {
            return 3;
        }
        default: {
            return 0;
        }
    }
}

export function Skill_isAthletics(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function Skill_isStealth(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function Skill_isPerception(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function Skill_isInsight(x) {
    if (x.tag === 3) {
        return true;
    }
    else {
        return false;
    }
}

export function ElfRace_toString(x) {
    switch (x.tag) {
        case 1: {
            return "Wood";
        }
        case 2: {
            return "Drow";
        }
        default: {
            return "High";
        }
    }
}

export function ElfRace_fromString(x) {
    switch (x) {
        case "High": {
            return new Character_ElfRace(0);
        }
        case "Wood": {
            return new Character_ElfRace(1);
        }
        case "Drow": {
            return new Character_ElfRace(2);
        }
        default: {
            return void 0;
        }
    }
}

export function ElfRace_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        default: {
            return 0;
        }
    }
}

export function ElfRace_isHigh(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function ElfRace_isWood(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function ElfRace_isDrow(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function DwarfRace_toString(x) {
    if (x.tag === 1) {
        return "Hill";
    }
    else {
        return "Mountain";
    }
}

export function DwarfRace_fromString(x) {
    switch (x) {
        case "Mountain": {
            return new Character_DwarfRace(0);
        }
        case "Hill": {
            return new Character_DwarfRace(1);
        }
        default: {
            return void 0;
        }
    }
}

export function DwarfRace_toTag(x) {
    if (x.tag === 1) {
        return 1;
    }
    else {
        return 0;
    }
}

export function DwarfRace_isMountain(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function DwarfRace_isHill(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function HumanType_toString(x) {
    if (x.tag === 1) {
        return "Variant";
    }
    else {
        return "Standard";
    }
}

export function HumanType_fromString(x) {
    if (x === "Standard") {
        return new Character_HumanType(0);
    }
    else {
        return void 0;
    }
}

export function HumanType_toTag(x) {
    if (x.tag === 1) {
        return 1;
    }
    else {
        return 0;
    }
}

export function HumanType_isStandard(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function HumanType_isVariant(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function Race_toString(x) {
    switch (x.tag) {
        case 1: {
            return "Elf";
        }
        case 2: {
            return "Dwarf";
        }
        case 3: {
            return "Halforc";
        }
        case 4: {
            return "Goblin";
        }
        default: {
            return "Human";
        }
    }
}

export function Race_fromString(x) {
    switch (x) {
        case "Halforc": {
            return new Character_Race(3);
        }
        case "Goblin": {
            return new Character_Race(4);
        }
        default: {
            return void 0;
        }
    }
}

export function Race_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        case 3: {
            return 3;
        }
        case 4: {
            return 4;
        }
        default: {
            return 0;
        }
    }
}

export function Race_isHuman(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function Race_isElf(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function Race_isDwarf(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function Race_isHalforc(x) {
    if (x.tag === 3) {
        return true;
    }
    else {
        return false;
    }
}

export function Race_isGoblin(x) {
    if (x.tag === 4) {
        return true;
    }
    else {
        return false;
    }
}

export function Class_toString(x) {
    switch (x.tag) {
        case 1: {
            return "Fighter";
        }
        case 2: {
            return "Monk";
        }
        case 3: {
            return "Rogue";
        }
        default: {
            return "Barbarian";
        }
    }
}

export function Class_fromString(x) {
    switch (x) {
        case "Barbarian": {
            return new Character_Class(0);
        }
        case "Fighter": {
            return new Character_Class(1);
        }
        case "Monk": {
            return new Character_Class(2);
        }
        case "Rogue": {
            return new Character_Class(3);
        }
        default: {
            return void 0;
        }
    }
}

export function Class_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        case 3: {
            return 3;
        }
        default: {
            return 0;
        }
    }
}

export function Class_isBarbarian(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function Class_isFighter(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function Class_isMonk(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function Class_isRogue(x) {
    if (x.tag === 3) {
        return true;
    }
    else {
        return false;
    }
}

export function FightingStyle_toString(x) {
    switch (x.tag) {
        case 1: {
            return "Archery";
        }
        case 2: {
            return "Defense";
        }
        case 3: {
            return "GreatWeaponFighting";
        }
        default: {
            return "Dueling";
        }
    }
}

export function FightingStyle_fromString(x) {
    switch (x) {
        case "Dueling": {
            return new Character_FightingStyle(0);
        }
        case "Archery": {
            return new Character_FightingStyle(1);
        }
        case "Defense": {
            return new Character_FightingStyle(2);
        }
        case "GreatWeaponFighting": {
            return new Character_FightingStyle(3);
        }
        default: {
            return void 0;
        }
    }
}

export function FightingStyle_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        case 3: {
            return 3;
        }
        default: {
            return 0;
        }
    }
}

export function FightingStyle_isDueling(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function FightingStyle_isArchery(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function FightingStyle_isDefense(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function FightingStyle_isGreatWeaponFighting(x) {
    if (x.tag === 3) {
        return true;
    }
    else {
        return false;
    }
}

export function Subclass_toString(x) {
    switch (x.tag) {
        case 1: {
            return "EldritchKnight";
        }
        case 2: {
            return "Samurai";
        }
        case 3: {
            return "Zealot";
        }
        case 4: {
            return "Swashbuckler";
        }
        case 5: {
            return "FourElements";
        }
        default: {
            return "Champion";
        }
    }
}

export function Subclass_fromString(x) {
    switch (x) {
        case "Champion": {
            return new Character_Subclass(0);
        }
        case "EldritchKnight": {
            return new Character_Subclass(1);
        }
        case "Samurai": {
            return new Character_Subclass(2);
        }
        case "Zealot": {
            return new Character_Subclass(3);
        }
        case "Swashbuckler": {
            return new Character_Subclass(4);
        }
        case "FourElements": {
            return new Character_Subclass(5);
        }
        default: {
            return void 0;
        }
    }
}

export function Subclass_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        case 3: {
            return 3;
        }
        case 4: {
            return 4;
        }
        case 5: {
            return 5;
        }
        default: {
            return 0;
        }
    }
}

export function Subclass_isChampion(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function Subclass_isEldritchKnight(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function Subclass_isSamurai(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function Subclass_isZealot(x) {
    if (x.tag === 3) {
        return true;
    }
    else {
        return false;
    }
}

export function Subclass_isSwashbuckler(x) {
    if (x.tag === 4) {
        return true;
    }
    else {
        return false;
    }
}

export function Subclass_isFourElements(x) {
    if (x.tag === 5) {
        return true;
    }
    else {
        return false;
    }
}

export function ClassAbility_toString(x) {
    switch (x.tag) {
        case 1: {
            return "FightingStyle";
        }
        case 2: {
            return "ExtraAttack";
        }
        case 3: {
            return "SecondWind";
        }
        case 4: {
            return "Indomitable";
        }
        case 5: {
            return "Subclass";
        }
        default: {
            return "ASIChoice";
        }
    }
}

export function ClassAbility_fromString(x) {
    return void 0;
}

export function ClassAbility_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        case 3: {
            return 3;
        }
        case 4: {
            return 4;
        }
        case 5: {
            return 5;
        }
        default: {
            return 0;
        }
    }
}

export function ClassAbility_isASIChoice(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function ClassAbility_isFightingStyle(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function ClassAbility_isExtraAttack(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function ClassAbility_isSecondWind(x) {
    if (x.tag === 3) {
        return true;
    }
    else {
        return false;
    }
}

export function ClassAbility_isIndomitable(x) {
    if (x.tag === 4) {
        return true;
    }
    else {
        return false;
    }
}

export function ClassAbility_isSubclass(x) {
    if (x.tag === 5) {
        return true;
    }
    else {
        return false;
    }
}

export function Trait_toString(x) {
    switch (x.tag) {
        case 1: {
            return "Class";
        }
        case 2: {
            return "Feat";
        }
        case 3: {
            return "ASI";
        }
        case 4: {
            return "Skill";
        }
        default: {
            return "Race";
        }
    }
}

export function Trait_fromString(x) {
    return void 0;
}

export function Trait_toTag(x) {
    switch (x.tag) {
        case 1: {
            return 1;
        }
        case 2: {
            return 2;
        }
        case 3: {
            return 3;
        }
        case 4: {
            return 4;
        }
        default: {
            return 0;
        }
    }
}

export function Trait_isRace(x) {
    if (x.tag === 0) {
        return true;
    }
    else {
        return false;
    }
}

export function Trait_isClass(x) {
    if (x.tag === 1) {
        return true;
    }
    else {
        return false;
    }
}

export function Trait_isFeat(x) {
    if (x.tag === 2) {
        return true;
    }
    else {
        return false;
    }
}

export function Trait_isASI(x) {
    if (x.tag === 3) {
        return true;
    }
    else {
        return false;
    }
}

export function Trait_isSkill(x) {
    if (x.tag === 4) {
        return true;
    }
    else {
        return false;
    }
}

export const Stats_str_ = Lens$2_create((data) => data.str, (value, data_1) => (new Character_Stats(value, data_1.dex, data_1.con, data_1.int, data_1.wis, data_1.cha)));

export const Stats_dex_ = Lens$2_create((data) => data.dex, (value, data_1) => (new Character_Stats(data_1.str, value, data_1.con, data_1.int, data_1.wis, data_1.cha)));

export const Stats_con_ = Lens$2_create((data) => data.con, (value, data_1) => (new Character_Stats(data_1.str, data_1.dex, value, data_1.int, data_1.wis, data_1.cha)));

export const Stats_int_ = Lens$2_create((data) => data.int, (value, data_1) => (new Character_Stats(data_1.str, data_1.dex, data_1.con, value, data_1.wis, data_1.cha)));

export const Stats_wis_ = Lens$2_create((data) => data.wis, (value, data_1) => (new Character_Stats(data_1.str, data_1.dex, data_1.con, data_1.int, value, data_1.cha)));

export const Stats_cha_ = Lens$2_create((data) => data.cha, (value, data_1) => (new Character_Stats(data_1.str, data_1.dex, data_1.con, data_1.int, data_1.wis, value)));

export const CharacterSheet_stats_ = Lens$2_create((data) => data.stats, (value, data_1) => (new Character_CharacterSheet(value, data_1.unmodifiedStats, data_1.name, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const CharacterSheet_unmodifiedStats_ = Lens$2_create((data) => data.unmodifiedStats, (value, data_1) => (new Character_CharacterSheet(data_1.stats, value, data_1.name, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const CharacterSheet_name_ = Lens$2_create((data) => data.name, (value, data_1) => (new Character_CharacterSheet(data_1.stats, data_1.unmodifiedStats, value, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const CharacterSheet_sex_ = Lens$2_create((data) => data.sex, (value, data_1) => (new Character_CharacterSheet(data_1.stats, data_1.unmodifiedStats, data_1.name, value, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const CharacterSheet_race_ = Lens$2_create((data) => data.race, (value, data_1) => (new Character_CharacterSheet(data_1.stats, data_1.unmodifiedStats, data_1.name, data_1.sex, value, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const CharacterSheet_xp_ = Lens$2_create((data) => data.xp, (value, data_1) => (new Character_CharacterSheet(data_1.stats, data_1.unmodifiedStats, data_1.name, data_1.sex, data_1.race, value, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const CharacterSheet_allocatedLevels_ = Lens$2_create((data) => data.allocatedLevels, (value, data_1) => (new Character_CharacterSheet(data_1.stats, data_1.unmodifiedStats, data_1.name, data_1.sex, data_1.race, data_1.xp, value, data_1.subclasses, data_1.classAbilities)));

export const CharacterSheet_subclasses_ = Lens$2_create((data) => data.subclasses, (value, data_1) => (new Character_CharacterSheet(data_1.stats, data_1.unmodifiedStats, data_1.name, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, value, data_1.classAbilities)));

export const CharacterSheet_classAbilities_ = Lens$2_create((data) => data.classAbilities, (value, data_1) => (new Character_CharacterSheet(data_1.stats, data_1.unmodifiedStats, data_1.name, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, value)));

export const StatBlock_stats_ = Lens$2_create((data) => data.stats, (value, data_1) => (new StatBlock(value, data_1.hp, data_1.ac)));

export const StatBlock_hp_ = Lens$2_create((data) => data.hp, (value, data_1) => (new StatBlock(data_1.stats, value, data_1.ac)));

export const StatBlock_ac_ = Lens$2_create((data) => data.ac, (value, data_1) => (new StatBlock(data_1.stats, data_1.hp, value)));

export const CharSheet_statBlock_ = Lens$2_create((data) => data.statBlock, (value, data_1) => (new CharSheet(value, data_1.xp, data_1.yearOfBirth, data_1.sex)));

export const CharSheet_xp_ = Lens$2_create((data) => data.xp, (value, data_1) => (new CharSheet(data_1.statBlock, value, data_1.yearOfBirth, data_1.sex)));

export const CharSheet_yearOfBirth_ = Lens$2_create((data) => data.yearOfBirth, (value, data_1) => (new CharSheet(data_1.statBlock, data_1.xp, value, data_1.sex)));

export const CharSheet_sex_ = Lens$2_create((data) => data.sex, (value, data_1) => (new CharSheet(data_1.statBlock, data_1.xp, data_1.yearOfBirth, value)));

export const Creature_name_ = Lens$2_create((data) => data.name, (value, data_1) => (new Creature(value, data_1.stats)));

export const Creature_stats_ = Lens$2_create((data) => data.stats, (value, data_1) => (new Creature(data_1.name, value)));

export const DraftSheet_unmodifiedStats_ = Lens$2_create((data) => data.unmodifiedStats, (value, data_1) => (new Draft_DraftSheet(value, data_1.explicitName, data_1.autoName, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const DraftSheet_explicitName_ = Lens$2_create((data) => data.explicitName, (value, data_1) => (new Draft_DraftSheet(data_1.unmodifiedStats, value, data_1.autoName, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const DraftSheet_autoName_ = Lens$2_create((data) => data.autoName, (value, data_1) => (new Draft_DraftSheet(data_1.unmodifiedStats, data_1.explicitName, value, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const DraftSheet_sex_ = Lens$2_create((data) => data.sex, (value, data_1) => (new Draft_DraftSheet(data_1.unmodifiedStats, data_1.explicitName, data_1.autoName, value, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const DraftSheet_race_ = Lens$2_create((data) => data.race, (value, data_1) => (new Draft_DraftSheet(data_1.unmodifiedStats, data_1.explicitName, data_1.autoName, data_1.sex, value, data_1.xp, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const DraftSheet_xp_ = Lens$2_create((data) => data.xp, (value, data_1) => (new Draft_DraftSheet(data_1.unmodifiedStats, data_1.explicitName, data_1.autoName, data_1.sex, data_1.race, value, data_1.allocatedLevels, data_1.subclasses, data_1.classAbilities)));

export const DraftSheet_allocatedLevels_ = Lens$2_create((data) => data.allocatedLevels, (value, data_1) => (new Draft_DraftSheet(data_1.unmodifiedStats, data_1.explicitName, data_1.autoName, data_1.sex, data_1.race, data_1.xp, value, data_1.subclasses, data_1.classAbilities)));

export const DraftSheet_subclasses_ = Lens$2_create((data) => data.subclasses, (value, data_1) => (new Draft_DraftSheet(data_1.unmodifiedStats, data_1.explicitName, data_1.autoName, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, value, data_1.classAbilities)));

export const DraftSheet_classAbilities_ = Lens$2_create((data) => data.classAbilities, (value, data_1) => (new Draft_DraftSheet(data_1.unmodifiedStats, data_1.explicitName, data_1.autoName, data_1.sex, data_1.race, data_1.xp, data_1.allocatedLevels, data_1.subclasses, value)));

//# sourceMappingURL=AutoGen.fs.js.map
