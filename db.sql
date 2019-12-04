CREATE TABLE cliente (
	codigo SERIAL PRIMARY KEY,
	nome VARCHAR,
	cpf VARCHAR,
	endereco VARCHAR,
	bairro VARCHAR,
	cep VARCHAR,
	cidade VARCHAR,
	telefone VARCHAR,
	uf VARCHAR
);

CREATE TABLE produto (
	codigo SERIAL PRIMARY KEY,
	nome VARCHAR,
	valor INTEGER
);

CREATE TABLE nota (
	codigo SERIAL PRIMARY KEY,
	cliente INTEGER NOT NULL REFERENCES cliente(codigo),
	total INTEGER
);

CREATE TABLE produto_comprado (
	nota INTEGER NOT NULL REFERENCES nota(codigo),
	produto INTEGER NOT NULL REFERENCES produto(codigo),
	quantidade INTEGER,
	total INTEGER,
	data TIMESTAMP
);
