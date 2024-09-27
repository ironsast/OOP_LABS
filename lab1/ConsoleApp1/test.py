#include <iostream>
#include <cmath>
#include <functional>
#include <limits>

using namespace std;

// ������� ��� ���������� ���������� ������������ ��������� ������� f
// �� ��������� [left, right] � ����� step.
static double calculateIntegral(double left, double right, const function<double(double)>& f) {
    double step = 0.0001;  // ������ ��� ��������������
    double x = left;  // ��������� ����� ��������������
    double result = 0;  // ���������� ��� �������� ���������� ��������������

    // �������� �� ��������� �� left �� right � ����� step
    for (; x < right; x += step) {
        result += f(x) * step;  // ��������� � ���������� �������� ������� f(x) ���������� �� step
    }

    return result;  // ���������� ��������� ��������������
}

// ������� ��� ���������� ��������������� �������� ������������� f
// �� ��������� [left, right]. ������������ ��������� ��������������.
static double calculateMean(double left, double right, const function<double(double)>& f) {
    double integral = calculateIntegral(left, right, f);  // ��������� �������� ������� f

    // ��������� �������������� �������� ��� ��������� ��������� �� x*f(x)
    // � ��������� ����� ������� f �� �������� ���������
    return calculateIntegral(left, right, [&f, integral](double x) {
        return x * f(x) / integral;
        });
}

// ������� ��� ���������� ��������� ������������� f �� ��������� [left, right].
// � �������� ��������� ����� ��������� ������� �������� (mean).
static double calculateVariance(double left, double right, const function<double(double)>& f, double mean) {
    double integral = calculateIntegral(left, right, f);  // ��������� �������� ������� f

    // ��������� ��������� ��� ��������� ��������� �� (x - mean)^2 * f(x)
    // � ��������� ����� ������� f
    return calculateIntegral(left, right, [&f, mean](double x) {
        double diff = x - mean;
        return diff * diff * f(x);
        }) / integral;
}

// ������� ��� ���������� ���� ������������� f �� ��������� [left, right].
// ���� � ��� �����, � ������� ������� f ��������� ������ ������������� ��������.
static double findMode(double left, double right, const function<double(double)>& f) {
    double step = 0.0001;  // ��� ������ ���������
    double x = left;  // ��������� �����
    double mode = left;  // ���������� ��� �������� �������� ����
    double currentMax = -numeric_limits<double>::max();  // ���������� ��� �������� �������� ���������

    // �������� �� ��������� �� left �� right � ����� step
    for (; x < right; x += step) {
        double value = f(x);  // ��������� �������� ������� � ����� x

        // ���� ������� �������� ������, ��� ���������� ��������, ���������
        if (value > currentMax) {
            currentMax = value;
            mode = x;  // ��������� ����
        }
    }

    return mode;  // ���������� ��������� ����
}

// ������� ���������, �������� �� ���������� ������� f ���������� ������������� �����������.
// ���� ��, �� ��������� �������������� ��������, ��������� � ���� �������������.
static void processDistribution(double left, double right, const function<double(double)>& f) {
    double integral = calculateIntegral(left, right, f);  // ��������� �������� ������� f

    // ���������, �������� �� ������� ���������� ������������� (�������� ������ ���� > 0)
    if (integral <= 0) {
        cout << "������� �� ������������� ��������� ��������� ������������� �����������.\n";
        return;
    }

    // ��������� �������������� ��������, ��������� � ����
    double mean = calculateMean(left, right, f);
    double variance = calculateVariance(left, right, f, mean);
    double mode = findMode(left, right, f);

    // ������� ����������
    cout << "�������������� ��������: " << mean << endl;
    cout << "���������: " << variance << endl;
    cout << "����: " << mode << endl;
}

int main() {
    setlocale(LC_ALL, "Russian");

    // ������������� 1: �������� ������� f1 �� ��������� [-100, 2]
    double left1 = -100;
    double right1 = 2;
    auto f1 = [](double x) {
        if (x < 0) {
            return 0.0;  // �������� ������� �� ��������� ������� �����������
        }
        else if (x >= 0 && x <= 2) {
            return x - x * x * x / 4.0;  // ����������� ������� ������ �������
        }
        else { return 0.0; }  // �������� ������� �� ��������� �������
    };

    cout << "������������� 1:\n";
    processDistribution(left1, right1, f1);

    // ������������� 2: �������� ������� f2 �� ��������� [0, ?]
    double left2 = 0;
    double right2 = M_PI;
    auto f2 = [](double x) {
        if (x < 0 || x > M_PI) {
            return 0.0;  // �������� ������� �� ��������� �������
        } else { return 0.5 * sin(x); }  // ����������� ������� ������ �������
    };

    cout << "\n������������� 2:\n";
    processDistribution(left2, right2, f2);

    return 0;
}
