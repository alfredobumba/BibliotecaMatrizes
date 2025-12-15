// Descrição: Implementação das funções obrigatórias e auxiliares para operações com matrizes
// Este ficheiro contém as 9 funções obrigatórias do projeto mais 2 funções auxiliares

using System;

namespace BibliotecaMatrizes
{
    // Classe estática que contém todas as operações com matrizes
    // Estática significa que não precisamos criar objetos desta classe para usar suas funções
    public static class MatrizOperacoes
    {
        // ============================================================================
        // FUNÇÃO 1: Matrix_Read - Lê uma matriz do teclado
        // ============================================================================
        // Parâmetros:
        //   - linhas: número de linhas da matriz
        //   - colunas: número de colunas da matriz
        // Retorno: matriz preenchida com valores digitados pelo usuário
        public static double[,] Matrix_Read(int linhas, int colunas)
        {
            try
            {
                // Cria uma matriz com o número especificado de linhas e colunas
                double[,] matriz = new double[linhas, colunas];

                // Loop externo: percorre cada linha da matriz
                for (int i = 0; i < linhas; i++)
                {
                    // Loop interno: percorre cada coluna da linha atual
                    for (int j = 0; j < colunas; j++)
                    {
                        // Variável para controlar se a entrada foi válida
                        bool entradaValida = false;

                        // Loop que continua até o usuário digitar um número válido
                        while (!entradaValida)
                        {
                            // Escreve mensagem pedindo o elemento na posição [i,j]
                            Console.Write($"Elemento [{i},{j}]: ");

                            // Lê a entrada do usuário
                            string entrada = Console.ReadLine();

                            // Tenta converter a string digitada para double
                            // TryParse retorna true se conseguir converter, false caso contrário
                            if (double.TryParse(entrada, out double valor))
                            {
                                // Se a conversão foi bem-sucedida, armazena o valor na matriz
                                matriz[i, j] = valor;
                                // Marca que a entrada foi válida para sair do loop while
                                entradaValida = true;
                            }
                            else
                            {
                                // Se a conversão falhou, mostra mensagem de erro
                                Console.WriteLine("ERRO: Entrada inválida! Digite um número válido.");
                                // O loop while continua, pedindo novamente o valor
                            }
                        }
                    }
                }

                // Retorna a matriz preenchida com os valores digitados
                return matriz;
            }
            catch (Exception ex)
            {
                // Se ocorrer qualquer erro inesperado, mostra a mensagem
                Console.WriteLine($"ERRO: {ex.Message}");
                // Retorna null indicando que houve um erro
                return null;
            }
        }

        // ============================================================================
        // FUNÇÃO 2: Matrix_Scalar_Mult - Multiplica matriz por escalar
        // ============================================================================
        // Parâmetros:
        //   - matriz: matriz a ser multiplicada
        //   - escalar: número pelo qual multiplicar cada elemento
        // Retorno: nova matriz com cada elemento multiplicado pelo escalar
        public static double[,] Matrix_Scalar_Mult(double[,] matriz, double escalar)
        {
            try
            {
                // Verifica se a matriz não é nula (null)
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula.");
                    return null;
                }

                // Obtém o número de linhas da matriz usando GetLength(0)
                int linhas = matriz.GetLength(0);
                // Obtém o número de colunas da matriz usando GetLength(1)
                int colunas = matriz.GetLength(1);

                // Cria uma nova matriz para armazenar o resultado
                double[,] resultado = new double[linhas, colunas];

                // Loop externo: percorre cada linha
                for (int i = 0; i < linhas; i++)
                {
                    // Loop interno: percorre cada coluna
                    for (int j = 0; j < colunas; j++)
                    {
                        // Multiplica cada elemento pelo escalar e armazena no resultado
                        resultado[i, j] = matriz[i, j] * escalar;
                    }
                }

                // Retorna a matriz resultante
                return resultado;
            }
            catch (Exception ex)
            {
                // Captura e mostra qualquer erro que ocorrer
                Console.WriteLine($"ERRO: {ex.Message}");
                return null;
            }
        }

        // ============================================================================
        // FUNÇÃO 3: Matrix_Add - Soma duas matrizes
        // ============================================================================
        // Parâmetros:
        //   - A: primeira matriz
        //   - B: segunda matriz
        // Retorno: matriz resultante da soma A + B
        public static double[,] Matrix_Add(double[,] A, double[,] B)
        {
            try
            {
                // Verifica se alguma das matrizes é nula
                if (A == null || B == null)
                {
                    Console.WriteLine("ERRO: As matrizes não podem ser nulas.");
                    return null;
                }

                // Obtém as dimensões da matriz A
                int linhasA = A.GetLength(0);
                int colunasA = A.GetLength(1);

                // Obtém as dimensões da matriz B
                int linhasB = B.GetLength(0);
                int colunasB = B.GetLength(1);

                // Verifica se as matrizes têm as mesmas dimensões
                // Só podemos somar matrizes de mesma dimensão
                if (linhasA != linhasB || colunasA != colunasB)
                {
                    Console.WriteLine("ERRO: As matrizes devem ter as mesmas dimensões para serem somadas.");
                    return null;
                }

                // Cria matriz para o resultado
                double[,] resultado = new double[linhasA, colunasA];

                // Loop para percorrer todas as posições
                for (int i = 0; i < linhasA; i++)
                {
                    for (int j = 0; j < colunasA; j++)
                    {
                        // Soma os elementos correspondentes de A e B
                        resultado[i, j] = A[i, j] + B[i, j];
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return null;
            }
        }

        // ============================================================================
        // FUNÇÃO 4: Matrix_Mult - Multiplica duas matrizes
        // ============================================================================
        // Parâmetros:
        //   - A: primeira matriz (m x n)
        //   - B: segunda matriz (n x p)
        // Retorno: matriz resultante C (m x p) onde C = A × B
        public static double[,] Matrix_Mult(double[,] A, double[,] B)
        {
            try
            {
                // Verificação de matrizes nulas
                if (A == null || B == null)
                {
                    Console.WriteLine("ERRO: As matrizes não podem ser nulas.");
                    return null;
                }

                // Obtém dimensões: A é m×n, B é n×p
                int m = A.GetLength(0);  // linhas de A
                int n = A.GetLength(1);  // colunas de A
                int n2 = B.GetLength(0); // linhas de B
                int p = B.GetLength(1);  // colunas de B

                // Verifica compatibilidade: número de colunas de A deve igual número de linhas de B
                if (n != n2)
                {
                    Console.WriteLine("ERRO: Número de colunas da primeira matriz deve ser igual ao número de linhas da segunda.");
                    return null;
                }

                // Cria matriz resultado C com dimensões m×p
                double[,] C = new double[m, p];

                // Algoritmo de multiplicação matricial: três loops aninhados
                // Loop externo: percorre cada linha de A (m linhas)
                for (int i = 0; i < m; i++)
                {
                    // Loop do meio: percorre cada coluna de B (p colunas)
                    for (int j = 0; j < p; j++)
                    {
                        // Inicializa o elemento C[i,j] com zero
                        double soma = 0;

                        // Loop interno: calcula o produto escalar da linha i de A com a coluna j de B
                        // Este loop percorre os n elementos
                        for (int k = 0; k < n; k++)
                        {
                            // Multiplica elemento da linha i de A pelo elemento da coluna j de B
                            // e acumula na soma
                            soma += A[i, k] * B[k, j];
                        }

                        // Armazena o resultado na posição [i,j] da matriz C
                        C[i, j] = soma;
                    }
                }

                return C;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return null;
            }
        }

        // ============================================================================
        // FUNÇÃO 5: Matrix_Inverse_2x2 - Calcula inversa de matriz 2x2
        // ============================================================================
        // Parâmetros:
        //   - matriz: matriz 2x2 a ser invertida
        // Retorno: matriz inversa, ou null se não existir
        // Fórmula: Para matriz [a b; c d], inversa é (1/det)*[d -b; -c a]
        public static double[,] Matrix_Inverse_2x2(double[,] matriz)
        {
            try
            {
                // Verificação de matriz nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula.");
                    return null;
                }

                // Verifica se é realmente 2x2
                if (matriz.GetLength(0) != 2 || matriz.GetLength(1) != 2)
                {
                    Console.WriteLine("ERRO: A matriz deve ser 2x2.");
                    return null;
                }

                // Extrai os elementos da matriz
                // Matriz tem a forma: [a b]
                //                     [c d]
                double a = matriz[0, 0];
                double b = matriz[0, 1];
                double c = matriz[1, 0];
                double d = matriz[1, 1];

                // Calcula o determinante usando a função auxiliar
                double det = Matrix_Determinant_2x2(matriz);

                // Verifica se o determinante é zero (com tolerância numérica)
                // Se det = 0, a matriz não tem inversa
                if (Math.Abs(det) < 1e-10)
                {
                    Console.WriteLine("ERRO: Matriz não é invertível (determinante zero).");
                    return null;
                }

                // Cria a matriz inversa usando a fórmula
                // Inversa = (1/det) * [d  -b]
                //                     [-c  a]
                double[,] inversa = new double[2, 2];
                inversa[0, 0] = d / det;   // Elemento superior esquerdo
                inversa[0, 1] = -b / det;  // Elemento superior direito
                inversa[1, 0] = -c / det;  // Elemento inferior esquerdo
                inversa[1, 1] = a / det;   // Elemento inferior direito

                return inversa;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return null;
            }
        }

        // ============================================================================
        // FUNÇÃO 6: Matrix_Determinant_3x3 - Calcula determinante de matriz 3x3
        // ============================================================================
        // Parâmetros:
        //   - matriz: matriz 3x3
        // Retorno: valor do determinante
        // Método: Expansão de Laplace pela primeira linha
        public static double Matrix_Determinant_3x3(double[,] matriz)
        {
            try
            {
                // Verifica matriz nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula.");
                    return double.NaN;
                }

                // Verifica dimensões
                if (matriz.GetLength(0) != 3 || matriz.GetLength(1) != 3)
                {
                    Console.WriteLine("ERRO: A matriz deve ser 3x3.");
                    return double.NaN;
                }

                // Extrai todos os elementos da matriz 3x3
                // Matriz tem a forma: [a b c]
                //                     [d e f]
                //                     [g h i]
                double a = matriz[0, 0];
                double b = matriz[0, 1];
                double c = matriz[0, 2];
                double d = matriz[1, 0];
                double e = matriz[1, 1];
                double f = matriz[1, 2];
                double g = matriz[2, 0];
                double h = matriz[2, 1];
                double i = matriz[2, 2];

                // Aplica a regra de Sarrus (expansão pela primeira linha)
                // det = a(ei - fh) - b(di - fg) + c(dh - eg)
                double det = a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);

                return det;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return double.NaN;
            }
        }

        // ============================================================================
        // FUNÇÃO 7: Matrix_Transpose - Calcula transposta de uma matriz
        // ============================================================================
        // Parâmetros:
        //   - matriz: matriz a ser transposta
        // Retorno: matriz transposta (linhas viram colunas e vice-versa)
        public static double[,] Matrix_Transpose(double[,] matriz)
        {
            try
            {
                // Verifica matriz nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula.");
                    return null;
                }

                // Obtém dimensões originais
                int linhas = matriz.GetLength(0);
                int colunas = matriz.GetLength(1);

                // Cria matriz transposta com dimensões invertidas
                // Se original é m×n, transposta é n×m
                double[,] transposta = new double[colunas, linhas];

                // Loop para copiar elementos trocando índices
                for (int i = 0; i < linhas; i++)
                {
                    for (int j = 0; j < colunas; j++)
                    {
                        // Elemento [i,j] da original vai para [j,i] da transposta
                        transposta[j, i] = matriz[i, j];
                    }
                }

                return transposta;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return null;
            }
        }

        // ============================================================================
        // FUNÇÃO 8: Matrix_IsDiagonal - Verifica se matriz é diagonal
        // ============================================================================
        // Parâmetros:
        //   - matriz: matriz a verificar
        // Retorno: true se é diagonal, false caso contrário
        // Uma matriz é diagonal se todos os elementos fora da diagonal principal são zero
        public static bool Matrix_IsDiagonal(double[,] matriz)
        {
            try
            {
                // Verifica matriz nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula.");
                    return false;
                }

                // Obtém dimensões
                int linhas = matriz.GetLength(0);
                int colunas = matriz.GetLength(1);

                // Matriz diagonal deve ser quadrada
                if (linhas != colunas)
                {
                    return false;
                }

                // Percorre todos os elementos
                for (int i = 0; i < linhas; i++)
                {
                    for (int j = 0; j < colunas; j++)
                    {
                        // Se não está na diagonal principal (i != j)
                        if (i != j)
                        {
                            // Verifica se o elemento é diferente de zero (com tolerância)
                            if (Math.Abs(matriz[i, j]) > 1e-10)
                            {
                                // Se encontrou elemento não-zero fora da diagonal, não é diagonal
                                return false;
                            }
                        }
                    }
                }

                // Se chegou aqui, todos elementos fora da diagonal são zero
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return false;
            }
        }

        // ============================================================================
        // FUNÇÃO 9: Matrix_IsTriangular - Verifica se matriz é triangular superior
        // ============================================================================
        // Parâmetros:
        //   - matriz: matriz a verificar
        // Retorno: true se é triangular superior, false caso contrário
        // Uma matriz é triangular superior se todos elementos abaixo da diagonal são zero
        public static bool Matrix_IsTriangular(double[,] matriz)
        {
            try
            {
                // Verifica matriz nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula.");
                    return false;
                }

                // Obtém dimensões
                int linhas = matriz.GetLength(0);
                int colunas = matriz.GetLength(1);

                // Matriz triangular deve ser quadrada
                if (linhas != colunas)
                {
                    return false;
                }

                // Percorre apenas os elementos abaixo da diagonal
                for (int i = 0; i < linhas; i++)
                {
                    for (int j = 0; j < colunas; j++)
                    {
                        // Se está abaixo da diagonal (i > j)
                        if (i > j)
                        {
                            // Verifica se o elemento é diferente de zero
                            if (Math.Abs(matriz[i, j]) > 1e-10)
                            {
                                // Se encontrou elemento não-zero abaixo da diagonal
                                return false;
                            }
                        }
                    }
                }

                // Se chegou aqui, todos elementos abaixo da diagonal são zero
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return false;
            }
        }

        // ============================================================================
        // FUNÇÃO AUXILIAR: Matrix_Print - Imprime uma matriz formatada
        // ============================================================================
        // Parâmetros:
        //   - matriz: matriz a ser impressa
        // Não retorna nada (void), apenas imprime no console
        public static void Matrix_Print(double[,] matriz)
        {
            try
            {
                // Verifica se matriz é nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz nula.");
                    return;
                }

                // Obtém dimensões
                int linhas = matriz.GetLength(0);
                int colunas = matriz.GetLength(1);

                // Loop para cada linha
                for (int i = 0; i < linhas; i++)
                {
                    // Inicia a linha com colchete
                    Console.Write("[ ");

                    // Loop para cada coluna
                    for (int j = 0; j < colunas; j++)
                    {
                        // Imprime elemento formatado: 8 caracteres de largura, 2 casas decimais
                        Console.Write($"{matriz[i, j],8:F2} ");
                    }

                    // Fecha a linha com colchete
                    Console.WriteLine("]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }
        }

        // ============================================================================
        // FUNÇÃO AUXILIAR: Matrix_Determinant_2x2 - Calcula determinante 2x2
        // ============================================================================
        // Parâmetros:
        //   - matriz: matriz 2x2
        // Retorno: valor do determinante
        // Fórmula: Para matriz [a b; c d], det = ad - bc
        public static double Matrix_Determinant_2x2(double[,] matriz)
        {
            try
            {
                // Verifica matriz nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula.");
                    return double.NaN;
                }

                // Verifica dimensões
                if (matriz.GetLength(0) != 2 || matriz.GetLength(1) != 2)
                {
                    Console.WriteLine("ERRO: A matriz deve ser 2x2.");
                    return double.NaN;
                }

                // Extrai elementos
                double a = matriz[0, 0];
                double b = matriz[0, 1];
                double c = matriz[1, 0];
                double d = matriz[1, 1];

                // Aplica fórmula: det = ad - bc
                double det = a * d - b * c;

                return det;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return double.NaN;
            }
        }
    }
}