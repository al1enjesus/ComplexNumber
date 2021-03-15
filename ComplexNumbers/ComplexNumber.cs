using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexNumbers {
    class ComplexNumber {
        public ComplexNumber(float realPart = 0, float imaginePart = 0) {
            SetFraction(realPart, imaginePart);
        }

        public void SetFraction(float realPart = 0, float imaginePart = 0) {
            _realPart = realPart;
            _imaginePart = imaginePart;
        }

        public float GetRealPart() {
            return _realPart;
        }

        public float GetImaginePart() {
            return _imaginePart;
        }

        public override int GetHashCode() {
            return _realPart.GetHashCode() ^ _imaginePart.GetHashCode();
        }

        public static ComplexNumber operator +(ComplexNumber lhs, ComplexNumber rhs) {
            float newReal, newImagine;
            checked {
                newReal = lhs.GetRealPart() + rhs.GetRealPart();
                newImagine = lhs.GetImaginePart() + rhs.GetImaginePart();
            }
            return new ComplexNumber(newReal, newImagine);
        }

        public static ComplexNumber operator -(ComplexNumber lhs, ComplexNumber rhs) {
            float newReal, newImagine;
            checked {
                newReal = lhs.GetRealPart() - rhs.GetRealPart();
                newImagine = lhs.GetImaginePart() - rhs.GetImaginePart();
            }
            return new ComplexNumber(newReal, newImagine);
        }

        public static ComplexNumber operator *(ComplexNumber lhs, ComplexNumber rhs) {
            float newReal, newImagine;
            checked {
                newReal = lhs.GetRealPart() * rhs.GetRealPart() - lhs.GetImaginePart() * rhs.GetImaginePart();
                newImagine = lhs.GetImaginePart() * rhs.GetRealPart() + lhs.GetRealPart() * rhs.GetImaginePart();
            }
            return new ComplexNumber(newReal, newImagine);
        }

        public static ComplexNumber operator /(ComplexNumber lhs, ComplexNumber rhs) {
            float newReal, newImagine;
            checked {
                float realNumerator = lhs.GetRealPart() * rhs.GetRealPart() + lhs.GetImaginePart() * rhs.GetImaginePart();
                float realDenominator = rhs.GetRealPart() * rhs.GetRealPart() + rhs.GetImaginePart() * rhs.GetImaginePart();
                newReal = realNumerator / realDenominator;

                float imagineNumeartor = lhs.GetImaginePart() * rhs.GetRealPart() - lhs.GetRealPart() * rhs.GetImaginePart();
                float imagineDenominator = realDenominator;
                newImagine = imagineNumeartor / imagineDenominator;
            }
            return new ComplexNumber(newReal, newImagine);
        }


        public static bool operator ==(ComplexNumber lhs, ComplexNumber rhs) {
            return (lhs._realPart == rhs._realPart && lhs._imaginePart == rhs._imaginePart);
        }
        public static bool operator != (ComplexNumber lhs, ComplexNumber rhs) {
            return !(lhs == rhs);
        }
        public override string ToString() {
            bool isImaginePartNegative = _imaginePart < 0 ? true : false;
            
            if(isImaginePartNegative) {
                return Convert.ToString(Convert.ToString(_realPart) + Convert.ToString(_imaginePart) + "i" );
            }
            else {
                return Convert.ToString(Convert.ToString(_realPart) + "+" + Convert.ToString(_imaginePart) + "i");
            }
        }

        private float _realPart;
        private float _imaginePart;
    }
}