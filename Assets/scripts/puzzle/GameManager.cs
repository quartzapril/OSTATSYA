using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  [SerializeField] private Transform gameTransform;
  [SerializeField] private Transform piecePrefab;

  private List<Transform> pieces;
  private int emptyLocation;
  private int size;
  private bool shuffling = false;

  // Создает игровое поле с size x size элементами.
  private void CreateGamePieces(float gapThickness) {
    // Ширина каждого тайла.
    float width = 1 / (float)size;
    for (int row = 0; row < size; row++) {
      for (int col = 0; col < size; col++) {
        Transform piece = Instantiate(piecePrefab, gameTransform);
        pieces.Add(piece);
        // Тайлы располагаются на игровом поле в диапазоне от -1 до +1.
        piece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                                          +1 - (2 * width * row) - width,
                                          0);
        piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
        piece.name = $"{(row * size) + col}";
        // Пустое место должно быть в правом нижнем углу.
        if ((row == size - 1) && (col == size - 1)) {
          emptyLocation = (size * size) - 1;
          piece.gameObject.SetActive(false);
        } else {
          // Настраиваем UV координаты соответствующим образом, они в диапазоне 0->1.
          float gap = gapThickness / 2;
          Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
          Vector2[] uv = new Vector2[4];
          // Порядок UV координат: (0, 1), (1, 1), (0, 0), (1, 0)
          uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
          uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
          uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
          uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));
          // Присваиваем новые UV координаты сетке.
          mesh.uv = uv;
        }
      }
    }
  }

  // Вызывается перед первым кадром
  void Start() {
    pieces = new List<Transform>();
    size = 4;
    CreateGamePieces(0.01f);
  }

  // Вызывается каждый кадр
  void Update() {
    // Проверка на завершение игры.
    if (!shuffling && CheckCompletion()) {
      shuffling = true;
      StartCoroutine(WaitShuffle(0.5f));
    }

    // При клике отправляем луч, чтобы проверить, кликнули ли мы на элемент.
    if (Input.GetMouseButtonDown(0)) {
      RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
      if (hit) {
        // Проходим по списку, индекс указывает на позицию.
        for (int i = 0; i < pieces.Count; i++) {
          if (pieces[i] == hit.transform) {
            // Проверяем каждое направление на допустимость хода.
            // Выходим при успехе, чтобы не выполнить обратный обмен.
            if (SwapIfValid(i, -size, size)) { break; }
            if (SwapIfValid(i, +size, size)) { break; }
            if (SwapIfValid(i, -1, 0)) { break; }
            if (SwapIfValid(i, +1, size - 1)) { break; }
          }
        }
      }
    }
  }

  // colCheck используется для предотвращения горизонтальных ходов с переносом.
  private bool SwapIfValid(int i, int offset, int colCheck) {
    if (((i % size) != colCheck) && ((i + offset) == emptyLocation)) {
      // Меняем местами в игровом состоянии.
      (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
      // Меняем местами их трансформы.
      (pieces[i].localPosition, pieces[i + offset].localPosition) = ((pieces[i + offset].localPosition, pieces[i].localPosition));
      // Обновляем позицию пустого места.
      emptyLocation = i;
      return true;
    }
    return false;
  }

  // Мы назвали элементы по порядку, чтобы использовать это для проверки завершения.
  private bool CheckCompletion() {
    for (int i = 0; i < pieces.Count; i++) {
      if (pieces[i].name != $"{i}") {
        return false;
      }
    }
    return true;
  }

  private IEnumerator WaitShuffle(float duration) {
    yield return new WaitForSeconds(duration);
    Shuffle();
    shuffling = false;
  }

  // Перемешивание "грубой силой".
  private void Shuffle() {
    int count = 0;
    int last = 0;
    while (count < (size * size * size)) {
      // Выбираем случайную позицию.
      int rnd = Random.Range(0, size * size);
      // Единственное, что запрещаем - отмену последнего хода.
      if (rnd == last) { continue; }
      last = emptyLocation;
      // Проверяем окружающие позиции в поисках допустимого хода.
      if (SwapIfValid(rnd, -size, size)) {
        count++;
      } else if (SwapIfValid(rnd, +size, size)) {
        count++;
      } else if (SwapIfValid(rnd, -1, 0)) {
        count++;
      } else if (SwapIfValid(rnd, +1, size - 1)) {
        count++;
      }
    }
  }
}