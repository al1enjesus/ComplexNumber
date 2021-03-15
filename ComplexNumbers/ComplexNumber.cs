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
        
        public float RealPart { get => _realPart; private set { _realPart = value; } }
        public float ImaginePart { get => _imaginePart; private set { _imaginePart = value; } }

        public override int GetHashCode() {
            RealPart = 0;
            return _realPart.GetHashCode() ^ _imaginePart.GetHashCode();
        }

        public static ComplexNumber operator +(ComplexNumber lhs, ComplexNumber rhs) {
            float newReal, newImagine;
            checked {
                newReal = lhs.RealPart + rhs.RealPart;
                newImagine = lhs.ImaginePart + rhs.ImaginePart;
            }
            return new ComplexNumber(newReal, newImagine);
        }

        public static ComplexNumber operator -(ComplexNumber lhs, ComplexNumber rhs) {
            float newReal, newImagine;
            checked {
                newReal = lhs.RealPart - rhs.RealPart;
                newImagine = lhs.ImaginePart - rhs.ImaginePart;
            }
            return new ComplexNumber(newReal, newImagine);
        }

        public static ComplexNumber operator *(ComplexNumber lhs, ComplexNumber rhs) {
            float newReal, newImagine;
            checked {
                newReal = lhs.RealPart * rhs.RealPart - lhs.ImaginePart * rhs.ImaginePart;
                newImagine = lhs.ImaginePart * rhs.RealPart + lhs.RealPart * rhs.ImaginePart;
            }
            return new ComplexNumber(newReal, newImagine);
        }

        public static ComplexNumber operator /(ComplexNumber lhs, ComplexNumber rhs) {
            float newReal, newImagine;
            checked {
                float realNumerator = lhs.RealPart * rhs.RealPart + lhs.ImaginePart * rhs.ImaginePart;
                float realDenominator = rhs.RealPart * rhs.RealPart + rhs.ImaginePart * rhs.ImaginePart;
                float imagineNumeartor = lhs.ImaginePart * rhs.RealPart - lhs.RealPart * rhs.ImaginePart;
                float imagineDenominator = realDenominator;

                if(realDenominator == 0 || imagineDenominator == 0) {
                    throw new Exception("Division by zero");
                }

                newReal = realNumerator / realDenominator;
                newImagine = imagineNumeartor / imagineDenominator;
            }
            return new ComplexNumber(newReal, newImagine);
        }


        public static bool operator ==(ComplexNumber lhs, ComplexNumber rhs) {
            return (lhs._realPart == rhs._realPart && lhs._imaginePart == rhs._imaginePart);
        }

        public static bool operator !=(ComplexNumber lhs, ComplexNumber rhs) {
            return !(lhs == rhs);
        }

        //Сравнения по модулю
        public static bool operator >(ComplexNumber lhs, ComplexNumber rhs) {
            float lhsModule, rhsModule;
            checked {
                lhsModule = lhs._realPart * lhs._realPart + lhs._imaginePart * lhs._imaginePart;
                rhsModule = rhs._realPart * rhs._realPart + rhs._imaginePart * rhs._imaginePart;
            }
            return lhsModule > rhsModule;
        }
        public static bool operator <(ComplexNumber lhs, ComplexNumber rhs) {
            return (!(lhs > rhs) && !(lhs == rhs));
        }

        public static bool operator >=(ComplexNumber lhs, ComplexNumber rhs) {
            return ((lhs > rhs) || (lhs == rhs));
        }

        public static bool operator <=(ComplexNumber lhs, ComplexNumber rhs) {
            return ((lhs < rhs) || (lhs == rhs));
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