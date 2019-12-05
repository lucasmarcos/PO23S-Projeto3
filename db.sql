DROP TABLE IF EXISTS produto_comprado;
DROP TABLE IF EXISTS nota;
DROP TABLE IF EXISTS produto;
DROP TABLE IF EXISTS cliente;

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
	valor INT,
	unidade VARCHAR
);

CREATE TABLE nota (
	codigo SERIAL PRIMARY KEY,
	cliente INT NOT NULL REFERENCES cliente(codigo),
	data TIMESTAMP
);

CREATE TABLE produto_comprado (
	nota INT NOT NULL REFERENCES nota(codigo) ON DELETE CASCADE,
	produto INT NOT NULL REFERENCES produto(codigo) ON DELETE CASCADE,
	quantidade INT
);
