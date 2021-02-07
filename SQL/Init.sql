/* ユーザーテーブルの定義 */
CREATE TABLE user {
	u_id   INTEGER,
	u_name CHAR(30),
	mail   CHAR(20)
	pass   CHAR(8)
};

/* 収納テーブルの定義 */
CREATE TABLE drawr {
	d_id   INTEGER,
	d_name CHAR(30),
	i_id   INTEGER
};

/* アイテムテーブルの定義 */
CREATE TABLE item {
	i_id   INTEGER,
	i_name CHAR(30)
};
