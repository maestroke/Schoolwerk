// LesOpgaveW5.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include "string.h"

using namespace std;

#define unit_mask 1
#define treasure_mask 2
#define extraction_mask 3
#define road_mask 4
#define resource_mask 5
#define village_mask 6
#define terrain_mask1 7
#define terrain_mask2 8

#define player_bits 4;
#define unit_type_bits 4;

//#define unemployed_mask 1
//#define settler_mask 2


struct Field {
	unsigned char field;
	unsigned char unit;
};

void set_village(Field &field);

bool mine_allowed(Field field);

int get_player(Field field);
int get_unit(Field field);

void make_road(Field &field);
bool has_road(Field field);

int main() {
	Field f;
	Field g;
	
	make_road(f);
	set_village(g);

	f.unit = (13 << 4);

	cout << has_road(f) << endl;
	cout << has_road(g) << endl;
	cout << (int)f.unit << " -> " << get_player(f) << endl;

	return 0;
}

void set_village(Field &field) {
	field.field |= (1 << village_mask);
}

bool mine_allowed(Field field) {
	return field.field & (1 << extraction_mask);
}

/*
	data:		10011000
	player:		1111XXXX
	unit:		XXXX1111
*/

int get_player(Field field) {
	return field.unit >> player_bits;
}

int get_unit(Field field) {
	return field.unit & 0x0F; // field.unit & 0000 1111;
}

void make_road(Field &field) {
	field.field |= (1 << road_mask);
}

bool has_road(Field field) {
	return field.field & (1 << road_mask);
}

